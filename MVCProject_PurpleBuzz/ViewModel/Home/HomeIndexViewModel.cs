﻿using System;
using MVCProject_PurpleBuzz.Models;

namespace MVCProject_PurpleBuzz.ViewModel.Home
{
	public class HomeIndexViewModel
	{
		public List<ProjectComponent> ProjectComponents { get; set; }
		public List<RecentWork> HomeRecentWorkComponent { get; set; }
        public List<RecentWork> RecentWorks { get; set; }

    }
}

