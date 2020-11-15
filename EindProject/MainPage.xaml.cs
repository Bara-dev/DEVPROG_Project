﻿using EindProject.Models;
using EindProject.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EindProject
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.LoadLeaderboard();
        }

        private async void LoadLeaderboard()
        {
            Leaders leaders = await WakaTimeRepo.GetLeaders();

            lvwLeaders.ItemsSource = leaders.users;
        }

        private async void TestModel()
        {
            Leaders leaders = await WakaTimeRepo.GetLeaders();

            Debug.WriteLine("Runnign Repo tests");
            Debug.WriteLine("Current Page: " + leaders.page);

            foreach (var leader in leaders.users)
            {
                Debug.WriteLine("User: " + leader.user.displayName + " at position #" + leader.rank);
            }
        }
    }
}