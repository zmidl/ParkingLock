using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Models
{
	public class MainDataModel:ViewModels.ViewModel
	{
		private string _Channel = "0";
		public string Channel
		{
			get { return _Channel; }
			set
			{
				_Channel = value;
				this.RaisePropertyChanged(nameof(Channel));
			}
		}

		private string _PanID = "0x0000";
		public string PanID
		{
			get { return _PanID; }
			set { _PanID = value; this.RaisePropertyChanged(nameof(PanID)); }
		}

		private string _LocalAddress = "0x0000";
		public string LocalAddress
		{
			get { return _LocalAddress; }
			set { _LocalAddress = value; this.RaisePropertyChanged(nameof(LocalAddress)); }
		}

		private string _TargetAddress = "0x0000";
		public string TargetAddress
		{
			get { return _TargetAddress; }
			set { _TargetAddress = value; this.RaisePropertyChanged(nameof(TargetAddress)); }
		}

		public MainDataModel()
		{
			 
		}
	}
}
