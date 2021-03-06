﻿using BLL.Concrete;
using BLL.ViewModels;
//using DAL.Concrete;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp_classwork2712
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       // private readonly RoleRepository _roleRepository;

        private readonly SqlConnection _con;


        private ShopWorkManager _sopWorkManager;


       public MainWindow()
        {
            string conStr = "Data Source=ALEXANDR;Initial Catalog=ProductDB;Integrated Security=True";
            
            _con = new SqlConnection(conStr);
            _con.Open();
            //  _roleRepository = new RoleRepository(_con);
            _sopWorkManager = new ShopWorkManager(_con);

            InitializeComponent();
            //  datagrid.ItemsSource = _roleRepository.Roles();


            ShopWorkerAddViewModel shopWorker = new ShopWorkerAddViewModel
            {
                Name = "Olexandr",
                Email = "sasha.momotuik@gmail.com",
                SurName = "Momotuik",
                Password = "123456qwerty",
                IsLocked = true,
                RoleId=1
                

            };
            _sopWorkManager.Add(shopWorker);

        }
    }
}
