using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileAccess.ViewModels
{
    using System.ComponentModel;
    using System.IO;
    using System.Threading.Tasks;
    using FileAccess.DataModels;
    using Newtonsoft.Json;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using Xamarin.Essentials;

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Account { get; set; }
        public string Password { get; set; }
        public string FilePath { get; set; }
        public DelegateCommand CleanCommand { get; set; }
        public DelegateCommand SyncFileReadCommand { get; set; }
        public DelegateCommand SyncFileWriteCommand { get; set; }
        public DelegateCommand AsyncSimpleFileReadCommand { get; set; }
        public DelegateCommand AsyncSimpleFileWriteCommand { get; set; }
        public DelegateCommand AsyncFileReadCommand { get; set; }
        public DelegateCommand AsyncFileWriteCommand { get; set; }
        string filename = "User.txt";
        private readonly INavigationService navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            CleanCommand = new DelegateCommand(() =>
            {
                Account = ""; Password = "";
            });
            SyncFileReadCommand = new DelegateCommand(() =>
            {
                string path = Path.Combine(FileSystem.AppDataDirectory, "Datas");
                if (Directory.Exists(path) == false) Directory.CreateDirectory(path);
                FilePath = Path.Combine(path, $"Sync{filename}");
                if (File.Exists(FilePath))
                {
                    var content = File.ReadAllText(FilePath);
                    var userInfo = JsonConvert.DeserializeObject<UserInfo>(content);
                    Account = userInfo.Account;
                    Password = userInfo.Password;
                }
            });
            SyncFileWriteCommand = new DelegateCommand(() =>
            {
                string path = Path.Combine(FileSystem.AppDataDirectory, "Datas");
                if (Directory.Exists(path) == false) Directory.CreateDirectory(path);
                FilePath = Path.Combine(path, $"Sync{filename}");
                var userInfo = new UserInfo()
                {
                    Account = Account,
                    Password = Password,
                };
                var content = JsonConvert.SerializeObject(userInfo);
                File.WriteAllText(FilePath, content);
            });
            AsyncSimpleFileReadCommand = new DelegateCommand(async () =>
            {
                string path = Path.Combine(FileSystem.AppDataDirectory, "Datas");
                if (Directory.Exists(path) == false) Directory.CreateDirectory(path);
                FilePath = Path.Combine(path, $"AsyncSimple{filename}");
                if (File.Exists(FilePath))
                {
                    var content = await Task.Run(() =>
                    {
                        return File.ReadAllText(FilePath);
                    });
                    var userInfo = JsonConvert.DeserializeObject<UserInfo>(content);
                    Account = userInfo.Account;
                    Password = userInfo.Password;
                }
            });
            AsyncSimpleFileWriteCommand = new DelegateCommand(async () =>
            {
                string path = Path.Combine(FileSystem.AppDataDirectory, "Datas");
                if (Directory.Exists(path) == false) Directory.CreateDirectory(path);
                FilePath = Path.Combine(path, $"AsyncSimple{filename}");
                var userInfo = new UserInfo()
                {
                    Account = Account,
                    Password = Password,
                };
                var content = JsonConvert.SerializeObject(userInfo);
                await Task.Run(() =>
                {
                    File.WriteAllText(FilePath, content);
                });
            });
            AsyncFileReadCommand = new DelegateCommand(async () =>
            {
                string path = Path.Combine(FileSystem.AppDataDirectory, "Datas");
                if (Directory.Exists(path) == false) Directory.CreateDirectory(path);
                FilePath = Path.Combine(path, $"Async{filename}");
                if (File.Exists(FilePath))
                {
                    using (var fileStream = File.Open(FilePath, FileMode.Open))
                    {
                        using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                        {
                            var content = await streamReader.ReadToEndAsync();
                            var userInfo = JsonConvert.DeserializeObject<UserInfo>(content);
                            Account = userInfo.Account;
                            Password = userInfo.Password;
                        }
                    }
                }
            });
            AsyncFileWriteCommand = new DelegateCommand(async () =>
            {
                string path = Path.Combine(FileSystem.AppDataDirectory, "Datas");
                if (Directory.Exists(path) == false) Directory.CreateDirectory(path);
                FilePath = Path.Combine(path, $"Async{filename}");
                using (var fileStream = File.Create(FilePath))
                {
                    using (var streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
                    {
                        var userInfo = new UserInfo()
                        {
                            Account = Account,
                            Password = Password,
                        };
                        var content = JsonConvert.SerializeObject(userInfo);
                        await streamWriter.WriteAsync(content);
                    }
                }
            });
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
