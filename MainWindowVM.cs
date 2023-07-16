using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IndividualProject.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace IndividualProject
{
    public  partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public  ObservableCollection<User> users;
        [ObservableProperty]
        public User selected=null;



        public void CloseMainWindow()
        {
            Application.Current.MainWindow.Close();
        }




        [RelayCommand]
        public void showmessage()
        {

            MessageBox.Show($"{selected.FirstName} GPA value must be between 0 and 4.", "Error");
        }

        [RelayCommand]
        public void AddStudent()
        {
            var vm = new AddUserVM();
            vm.title = "STUDENT REGISTRATION";
            AddNewUser window = new AddNewUser(vm);
            window.ShowDialog();

            if (vm.Student.FirstName != null)
            {
                users.Add(vm.Student);
            }
        }

        [RelayCommand]
        public void DeleteStudent()
        {
            if (selected != null)
            {
                string name = selected.FirstName;
                users.Remove(selected);
                MessageBox.Show($"{name} is Deleted successfuly.", "Delected");
                
            }
            else
            {
                MessageBox.Show("Plese Select Student before Delete.", "Error");


            }
        }
        [RelayCommand]
        public void EditStudent()
        {
            if (selected != null)
            {
                var vm = new AddUserVM(selected);
                vm.title = "EDIT USER";
                var window = new AddNewUser(vm);

                window.ShowDialog();


                int index = users.IndexOf(selected);
                users.RemoveAt(index);
                users.Insert(index, vm.Student);



            }
            else
            {
                MessageBox.Show("Please Select the student", "Error");
            }
        }

        public  MainWindowVM()
        {
            users = new ObservableCollection<User>();
            BitmapImage image1 = new BitmapImage(new Uri("/Model/Images/1.png", UriKind.Relative));
            users.Add(new User(21, "Jenny", "Ghmoaz", "22/1/2002",image1,3.0));
            BitmapImage image2 = new BitmapImage(new Uri("/Model/Images/2.jpg", UriKind.Relative));
            users.Add(new User(22, "Peter", "Parker", "12/1/2001",image2, 3.5));
            BitmapImage image3 = new BitmapImage(new Uri("/Model/Images/3.jpg", UriKind.Relative));
            users.Add(new User(23, "David", "Warner", "12/10/2000",image3,2.8));
            BitmapImage image4= new BitmapImage(new Uri("/Model/Images/4.png", UriKind.Relative));
            users.Add(new User(20, "Seleena", "Ghomaz", "02/9/2003", image4,2.5));

        }
    }
}
