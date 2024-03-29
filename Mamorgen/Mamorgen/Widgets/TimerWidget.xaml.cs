﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Mamorgen.Widgets
{
	public partial class TimerWidget : BaseWidget
	{
        public DateTime TickTo
        {
            get;
            set;
        }

        public Timer TickTimer
        {
            get;
            set;
        }

        private SynchronizationContext _SyncContext;

		public TimerWidget (string Tot, DateTime tickTo)
		{
            InitializeComponent();

            _SyncContext = SynchronizationContext.Current;
            TickTo = tickTo;
            TickTimer = new Timer((state) => UpdateTimer(), null, 1000, 1000);

            this.Tot.Text = Tot;
            UpdateTimer();
		}

        public void UpdateTimer()
        {
            var diff = TickTo - DateTime.Now;
            _SyncContext.Post(a => {
                Uur.Text = ((int)diff.TotalHours).ToString();
                Minuut.Text = diff.Minutes.ToString();
                Seconde.Text = diff.Seconds.ToString();
            }, null);
        }
	}
}
