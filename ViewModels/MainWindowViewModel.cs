using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.ViewModels
{
	public class MainWindowViewModel : ViewModel
	{
		private bool _IsQueried = false;

		private bool _IsReset = false;

		private bool _IsBatchModify = false;

		private ActionMode _ActionMode = ActionMode.None;

		private SerialPort _MySerialPort;

		private string _DisplayString;
		public string DisplayString
		{
			get { return _DisplayString; }
			set { _DisplayString = value; this.RaisePropertyChanged(nameof(DisplayString)); }
		}

		//private bool _IsPortOpened = false;
		public bool IsPortOpen
		{
			get { return this._MySerialPort == null ? false : this._MySerialPort.IsOpen; }
			set
			{
				if (this.IsPortOpen == false && value)
				{
					if (this.ExecuteOpenPort())
					{
						this.IsPortOpen = value;
						this.RaisePropertyChanged(nameof(IsPortOpen));
					}
				}
				else if (this.IsPortOpen && value == false)
				{
					if (this.ExecuteClosePort())
					{
						this.IsPortOpen = value;
						this.RaisePropertyChanged(nameof(IsPortOpen));
					}
				}
			}
		}

		public int _MyBuadRate { get; set; } = GeneralMethods.BuadRate;

		public int _MyDataBits { get; set; } = GeneralMethods.DataBits;

		private string[] _SerialPortNames = SerialPort.GetPortNames();
		public string[] SerialPortNames
		{
			get { return _SerialPortNames; }
			set
			{
				_SerialPortNames = value;
				this.RaisePropertyChanged(nameof(this.SerialPortNames));
			}
		}

		private string _SelectedPortName;
		public string SelectedPortName
		{
			get { return _SelectedPortName; }
			set
			{
				_SelectedPortName = value;
				this.RaisePropertyChanged(nameof(this.SelectedPortName));
			}
		}

		private byte _ChannelConfigurationInfo = 0x00;
		public byte ChannelConfigurationInfo
		{
			get { return _ChannelConfigurationInfo; }
			set
			{
				_ChannelConfigurationInfo = value;
				this.RaisePropertyChanged(nameof(ChannelConfigurationInfo));
			}
		}

		private byte[] _PanIDConfigurationInfo = new byte[] { 0x00, 0x00 };
		public byte[] PanIDConfigurationInfo
		{
			get { return _PanIDConfigurationInfo; }
			set { _PanIDConfigurationInfo = value; this.RaisePropertyChanged(nameof(PanIDConfigurationInfo)); }
		}

		private byte[] _LocalIDConfigurationInfo = new byte[] { 0x00, 0x00 };
		public byte[] LocalIDConfigurationInfo
		{
			get { return _LocalIDConfigurationInfo; }
			set { _LocalIDConfigurationInfo = value; this.RaisePropertyChanged(nameof(LocalIDConfigurationInfo)); }
		}

		private byte[] _TargetIDConfigurationInfo = new byte[] { 0x00, 0x00 };
		public byte[] TargetIDConfigurationInfo
		{
			get { return _TargetIDConfigurationInfo; }
			set { _TargetIDConfigurationInfo = value; this.RaisePropertyChanged(nameof(TargetIDConfigurationInfo)); }
		}

		private byte _ChannelModificationInfo = 0x00;
		public byte ChannelModificationInfo
		{
			get { return _ChannelModificationInfo; }
			set { _ChannelModificationInfo = value; this.RaisePropertyChanged(nameof(ChannelModificationInfo)); }
		}

		private byte[] _PanIDModificationInfo = new byte[] { 0x00, 0x00 };
		public byte[] PanIDModificationInfo
		{
			get { return _PanIDModificationInfo; }
			set
			{
				_PanIDModificationInfo = value;
				this.RaisePropertyChanged(nameof(PanIDModificationInfo));
			}
		}

		private byte[] _LocalIDModificationInfo = new byte[] { 0x00, 0x00 };
		public byte[] LocalIDModificationInfo
		{
			get { return _LocalIDModificationInfo; }
			set { _LocalIDModificationInfo = value; this.RaisePropertyChanged(nameof(LocalIDModificationInfo)); }
		}

		private byte[] _TargetIDModificationInfo = new byte[] { 0x00, 0x00 };
		public byte[] TargetIDModificationInfo
		{
			get { return _TargetIDModificationInfo; }
			set { _TargetIDModificationInfo = value; this.RaisePropertyChanged(nameof(TargetIDModificationInfo)); }
		}

		private string _BlueToothConfigurationInfo1;
		public string BlueToothConfigurationInfo1
		{
			get { return _BlueToothConfigurationInfo1; }
			set { _BlueToothConfigurationInfo1 = value; this.RaisePropertyChanged(nameof(BlueToothConfigurationInfo1)); }
		}

		private string _BlueToothConfigurationInfo2;
		public string BlueToothConfigurationInfo2
		{
			get { return _BlueToothConfigurationInfo2; }
			set { _BlueToothConfigurationInfo2 = value; this.RaisePropertyChanged(nameof(BlueToothConfigurationInfo2)); }
		}

		private string _BlueToothConfigurationInfo3;
		public string BlueToothConfigurationInfo3
		{
			get { return _BlueToothConfigurationInfo3; }
			set { _BlueToothConfigurationInfo3 = value; this.RaisePropertyChanged(nameof(BlueToothConfigurationInfo3)); }
		}

		private byte _HoldOn1;
		public byte HoldOn1
		{
			get { return _HoldOn1; }
			set { _HoldOn1 = value; this.RaisePropertyChanged(nameof(HoldOn1)); }
		}

		private byte _HoldOn2;
		public byte HoldOn2
		{
			get { return _HoldOn2; }
			set { _HoldOn2 = value; this.RaisePropertyChanged(nameof(HoldOn2)); }
		}

		private byte _HoldOn3;
		public byte HoldOn3
		{
			get { return _HoldOn3; }
			set { _HoldOn3 = value; this.RaisePropertyChanged(nameof(HoldOn3)); }
		}

		private byte _HoldOn4;
		public byte HoldOn4
		{
			get { return _HoldOn4; }
			set { _HoldOn4 = value; this.RaisePropertyChanged(nameof(HoldOn4)); }
		}

		private byte _Zigbee1;
		public byte Zigbee1
		{
			get { return _Zigbee1; }
			set { _Zigbee1 = value; this.RaisePropertyChanged(nameof(Zigbee1)); }
		}

		private byte _Zigbee2;
		public byte Zigbee2
		{
			get { return _Zigbee2; }
			set { _Zigbee2 = value; this.RaisePropertyChanged(nameof(Zigbee2)); }
		}

		private Models.MainDataModel _MainDataModel = new Models.MainDataModel();
		public Models.MainDataModel MainDataModel
		{
			get { return _MainDataModel; }
			set { _MainDataModel = value; this.RaisePropertyChanged(nameof(MainDataModel)); }
		}

		public RelayCommand QueryCommand { get; private set; }

		public RelayCommand ModifyChannelCommand { get; private set; }

		public RelayCommand ModifyPanIDCommand { get; private set; }

		public RelayCommand ModifyLocalIDCommand { get; private set; }

		public RelayCommand ModifyTargetIDInfoCommand { get; private set; }

		public RelayCommand OpenPortCommand { get; private set; }

		public RelayCommand ClosePortCommand { get; private set; }

		public RelayCommand ConfigureBlueToothCommand { get; private set; }

		public RelayCommand ConfigurePanIDCommand { get; private set; }

		public RelayCommand ConfigureCannelCommand { get; private set; }

		public RelayCommand ConfigureLocalIDCommand { get; private set; }

		public RelayCommand ConfigureTargetIDCommand { get; private set; }

		public RelayCommand ConfigureLockOnCommand { get; private set; }

		public RelayCommand ConfigureLockOffCommand { get; private set; }

		public RelayCommand ConfigureFinishCommand { get; private set; }

		public RelayCommand Write433Command { get; private set; }

		public RelayCommand WriteHoldOnCommand { get; private set; }

		public RelayCommand WriteZigbeeCommand { get; private set; }

		public RelayCommand ResetCommand { get; private set; }

		public RelayCommand BatchModifyCommand { get; private set; }

		public MainWindowViewModel()
		{
			this.QueryCommand = new RelayCommand(() => { this.WriteModifyInfo(ActionMode.None); });
			this.ModifyChannelCommand = new RelayCommand(() => { this.WriteModifyInfo(ActionMode.ModifyChannel); });
			this.ModifyPanIDCommand = new RelayCommand(() => { this.WriteModifyInfo(ActionMode.ModifyPanID); });
			this.ModifyLocalIDCommand = new RelayCommand(() => { this.WriteModifyInfo(ActionMode.ModifyLocalID); });
			this.ModifyTargetIDInfoCommand = new RelayCommand(() => { this.WriteModifyInfo(ActionMode.ModifyTargetID); });
			//this.OpenPortCommand = new RelayCommand(this.ExecuteOpenPort);
			//this.ClosePortCommand = new RelayCommand(this.ExecuteClosePort);
			this.ConfigureBlueToothCommand = new RelayCommand(() => { this.WriteConfigureInfo(ActionMode.BlueTooth); });
			this.ConfigurePanIDCommand = new RelayCommand(() => { this.WriteConfigureInfo(ActionMode.ConfigurPanID); });
			this.ConfigureCannelCommand = new RelayCommand(() => { this.WriteConfigureInfo(ActionMode.ConfigurChannel); });
			this.ConfigureLocalIDCommand = new RelayCommand(() => { this.WriteConfigureInfo(ActionMode.ConfigurLocalID); });
			this.ConfigureTargetIDCommand = new RelayCommand(() => { this.WriteConfigureInfo(ActionMode.ConfigurTargetID); });
			this.ConfigureLockOnCommand = new RelayCommand(() => { this.WriteModifyInfo(ActionMode.LockOn); });
			this.ConfigureLockOffCommand = new RelayCommand(() => { this.WriteModifyInfo(ActionMode.LockOff); });
			this.ConfigureFinishCommand = new RelayCommand(() => { this.WriteConfigureInfo(ActionMode.Finish); });
			this.Write433Command = new RelayCommand(() => { this.WriteModifyInfo(ActionMode._433); });
			this.WriteHoldOnCommand = new RelayCommand(() => { this.WriteModifyInfo(ActionMode.HoldOn); });
			this.WriteZigbeeCommand = new RelayCommand(() => { this.WriteModifyInfo(ActionMode.Zigbee); });
			this.ResetCommand = new RelayCommand(this.ExecuteReset);
			this.BatchModifyCommand = new RelayCommand(this.ExecuteBatchModify);
		}

		private void _MySerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			this.ReceiveData();
		}

		private void ReceiveData()
		{
			int length = this._MySerialPort.BytesToRead;
			if (this._IsQueried)
			{
				if (length.Equals(GeneralMethods.MODIFY_RESULT_LENGTH))
				{
					byte[] buffer = new byte[length];
					this._MySerialPort.Read(buffer, 0, buffer.Length);
					var resetInfo = this.EncodeRestoration(buffer[4], buffer[5]);
					this._MySerialPort.Write(resetInfo, 0, resetInfo.Length);
					this.ShowData(resetInfo);//打印复位信息
					this._IsQueried = false;
				}
				this._MySerialPort.DiscardInBuffer();
			}
			else
			{
				if (length.Equals(GeneralMethods.QUERY_RESULT_LENGTH))
				{
					byte[] buffer = new byte[length];
					this._MySerialPort.Read(buffer, 0, buffer.Length);
					this._MySerialPort.DiscardInBuffer();
					this.SwitchAction(buffer);
				}
				else
				{
					this._MySerialPort.DiscardInBuffer();
					this._MySerialPort.Write(GeneralMethods._QueryInfoHeader, 0, GeneralMethods._QueryInfoHeader.Length);
				}
			}
		}

		private void SwitchAction(byte[] buffer)
		{
			if (this._ActionMode.Equals(ActionMode.None))
			{
				this._IsQueried = false;

				this.MainDataModel.Channel = buffer[GeneralMethods.CHANNEL_INDEX].ToString();

				this.MainDataModel.PanID = GeneralMethods.UshortToHexString(buffer[GeneralMethods.PANID_HIGH_INDEX], buffer[GeneralMethods.PANID_LOW_INDEX]);

				this.MainDataModel.LocalAddress = GeneralMethods.UshortToHexString(buffer[GeneralMethods.LOCAL_LocalID_HIGH_INDEX], buffer[GeneralMethods.LOCAL_LocalID_LOW_INDEX]);

				this.MainDataModel.TargetAddress = GeneralMethods.UshortToHexString(buffer[GeneralMethods.TARGET_ADDRESS_HIGH_INDEX], buffer[GeneralMethods.TARGET_ADDRESS_LOW_INDEX]);

				this.ShowData(buffer);//打印查询信息
			}
			else if (this._ActionMode.Equals(ActionMode.HoldOn) ||
				this._ActionMode.Equals(ActionMode.LockOn) ||
				this._ActionMode.Equals(ActionMode.LockOff) ||
				this._ActionMode.Equals(ActionMode._433) ||
				this._ActionMode.Equals(ActionMode.Zigbee))
			{
				this._IsQueried = false;
				var high = default(byte);
				var low = default(byte);
				if (this._ActionMode.Equals(ActionMode._433) || this._ActionMode.Equals(ActionMode.LockOn) || this._ActionMode.Equals(ActionMode.LockOff))
				{ high = buffer[GeneralMethods.TARGET_ADDRESS_HIGH_INDEX]; low = buffer[GeneralMethods.TARGET_ADDRESS_LOW_INDEX]; }
				else { high = buffer[GeneralMethods.LOCAL_LocalID_HIGH_INDEX]; low = buffer[GeneralMethods.LOCAL_LocalID_LOW_INDEX]; }
				var sendingInfo = this.EncodeWriteOthers(high, low);
				this._MySerialPort.Write(sendingInfo, 0, sendingInfo.Length);
				this.ShowData(sendingInfo);
			}
			else
			{
				this._IsQueried = true;
				var sendingInfo = this.EncodeModifyInfo(buffer);
				this._MySerialPort.Write(sendingInfo, 0, sendingInfo.Length);
			}
		}

		private void SeitchDefault(ActionMode actionMode)
		{

		}

		private void ShowData(byte[] bytes)
		{
			StringBuilder sb = new StringBuilder();
			foreach (var c in bytes)
			{
				var cc = Convert.ToString(c, 16).ToUpper();
				if (cc.Length == 1) cc = "0" + cc;
				sb.Append(cc + " ");
			}
			this.DisplayString = sb.ToString();
		}

		private bool ExecuteOpenPort()
		{
			bool result = false;


			if (this._MySerialPort == null && this.SelectedPortName != null)
			{
				this._MySerialPort = new SerialPort();
				this._MySerialPort.PortName = this.SelectedPortName;
				this._MySerialPort.BaudRate = GeneralMethods.BuadRate;
				this._MySerialPort.DataBits = GeneralMethods.DataBits;
				this._MySerialPort.StopBits = GeneralMethods.StopBits;
				this._MySerialPort.Parity = GeneralMethods.Parity;
				this._MySerialPort.DataReceived += _MySerialPort_DataReceived;

				try
				{
					if (this._MySerialPort.IsOpen == false)
					{
						this._MySerialPort.Open();
						result = true;
					}
				}
				catch { result = false; }
			}

			return result;
		}

		private bool ExecuteClosePort()
		{
			bool result = true;
			if (this._MySerialPort != null)
			{
				if (this._MySerialPort.IsOpen)
				{
					try
					{
						this._MySerialPort.DataReceived -= _MySerialPort_DataReceived;
						this._MySerialPort.Close();
						this._MySerialPort = default(SerialPort);
					}
					catch { result = false; }
				}
			}
			return result;
		}

		private void ExecuteReset()
		{
			if (this._IsReset == false)
			{
				this._IsReset = true;
				Task task = Task.Factory.StartNew(() =>
				{
					for (int i = 0; i < 4; i++)
					{
						this._ActionMode = (ActionMode)i;
						this.WriteModifyInfo(this._ActionMode);
						Thread.Sleep(200);
					}
					this._IsReset = false;
				});
			}
		}

		private void ExecuteBatchModify()
		{
			if (this._IsBatchModify == false)
			{
				this._IsBatchModify = true;
				Task task = Task.Factory.StartNew(() =>
				{
					for (int i = 4; i < 8; i++)
					{
						this._ActionMode = (ActionMode)i;
						this.WriteModifyInfo(this._ActionMode);
						Thread.Sleep(200);
					}
					this._IsBatchModify = false;
				});
			}
		}

		private void WriteConfigureInfo(ActionMode actionMode)
		{
			this._ActionMode = actionMode;
			var sendingInfo = this.EncodeConfigureInfo();
			this._MySerialPort.Write(sendingInfo, 0, sendingInfo.Length);
			this.ShowData(sendingInfo);
		}

		private void WriteModifyInfo(ActionMode actionMode)
		{
			this._ActionMode = actionMode;
			this._MySerialPort.Write(GeneralMethods._QueryInfoHeader, 0, GeneralMethods._QueryInfoHeader.Length);
		}

		private byte[] EncodeModifyInfo(byte[] buffer)
		{
			var localAddressHigh = buffer[GeneralMethods.LOCAL_LocalID_HIGH_INDEX];
			var localAddressLow = buffer[GeneralMethods.LOCAL_LocalID_LOW_INDEX];

			if (this._ActionMode == ActionMode.ModifyChannel) buffer[GeneralMethods.CHANNEL_INDEX] = this.ChannelModificationInfo;
			else if (this._ActionMode == ActionMode.ResetChannel) buffer[GeneralMethods.CHANNEL_INDEX] = 11;
			else
			{
				byte[] bytes = default(byte[]);
				int highIndex = 0, lowIndex = 0;
				switch (this._ActionMode)
				{
					case ActionMode.ModifyPanID:
					{
						bytes = this.PanIDModificationInfo;
						highIndex = GeneralMethods.PANID_HIGH_INDEX;
						lowIndex = GeneralMethods.PANID_LOW_INDEX;
						break;
					}
					case ActionMode.ResetPanID:
					{
						bytes = new byte[] { 0x88, 0x88 };
						highIndex = GeneralMethods.PANID_HIGH_INDEX;
						lowIndex = GeneralMethods.PANID_LOW_INDEX;
						break;
					}
					case ActionMode.ModifyLocalID:
					{
						bytes = this.LocalIDModificationInfo;
						highIndex = GeneralMethods.LOCAL_LocalID_HIGH_INDEX;
						lowIndex = GeneralMethods.LOCAL_LocalID_LOW_INDEX;
						break;
					}
					case ActionMode.ResetLocalID:
					{
						bytes = new byte[] { 0x77, 0x77 };
						highIndex = GeneralMethods.LOCAL_LocalID_HIGH_INDEX;
						lowIndex = GeneralMethods.LOCAL_LocalID_LOW_INDEX;
						break;
					}
					case ActionMode.ModifyTargetID:
					{
						bytes = this.TargetIDModificationInfo;
						highIndex = GeneralMethods.TARGET_ADDRESS_HIGH_INDEX;
						lowIndex = GeneralMethods.TARGET_ADDRESS_LOW_INDEX;
						break;
					}
					case ActionMode.ResetTargetID:
					{
						bytes = new byte[] { 0x66, 0x66 };
						highIndex = GeneralMethods.TARGET_ADDRESS_HIGH_INDEX;
						lowIndex = GeneralMethods.TARGET_ADDRESS_LOW_INDEX;
						break;
					}
				}
				buffer[highIndex] = bytes[0];
				buffer[lowIndex] = bytes[1];
			}

			var deviceInfo = buffer.Skip(4).Take(65).ToArray();
			List<byte> sendingBuffer = new List<byte>();
			sendingBuffer.AddRange(GeneralMethods._ModifyInfoHeader);
			sendingBuffer.Add(localAddressHigh);
			sendingBuffer.Add(localAddressLow);
			sendingBuffer.AddRange(deviceInfo);
			sendingBuffer.Add(GeneralMethods.SumVerification(sendingBuffer.ToArray()));
			this._ActionMode = ActionMode.None;
			return sendingBuffer.ToArray();
		}

		private byte[] EncodeConfigureInfo()
		{
			byte[] result = default(byte[]);//this.ShowData(System.Text.Encoding.Default.GetBytes("TJSP-A-0002"));
			if (this._ActionMode.Equals(ActionMode.BlueTooth))
			{
				List<byte> buffer = new List<byte>(11);
				buffer.AddRange(new byte[] { 0x7F, 0x7F });
				buffer.AddRange(new byte[] { 0x84, 0x00, 0x10 });
				buffer.AddRange(GeneralMethods.StringToBytes(this.BlueToothConfigurationInfo1, 4));
				buffer.Add(0x2D);
				buffer.Add(GeneralMethods.StringToBytes(this.BlueToothConfigurationInfo2, 1)[0]);
				buffer.Add(0x2D);
				buffer.AddRange(GeneralMethods.StringToBytes(this.BlueToothConfigurationInfo3, 4));
				buffer.AddRange(GeneralMethods.GetCrcResult(buffer.ToArray()));
				buffer.AddRange(new byte[] { 0x0D, 0x0A });
				result = buffer.ToArray();
			}
			else
			{
				byte highByte = 0, lowByte = 0;
				byte[] head = default(byte[]);
				byte[] bytes = default(byte[]);
				switch (this._ActionMode)
				{
					case ActionMode.ConfigurChannel:
					{
						head = new byte[] { 0x83, 0x00, 0x00 };
						bytes = new byte[] { 0x00, this.ChannelConfigurationInfo };
						break;
					}
					case ActionMode.ConfigurPanID:
					{
						head = new byte[] { 0x82, 0x00, 0x00 };
						bytes = this.PanIDConfigurationInfo;
						break;
					}
					case ActionMode.ConfigurLocalID:
					{
						head = new byte[] { 0x80, 0x00, 0x00 };
						bytes = this.LocalIDConfigurationInfo;
						break;
					}
					case ActionMode.ConfigurTargetID:
					{
						head = new byte[] { 0x81, 0x00, 0x00 };
						bytes = this.TargetIDConfigurationInfo;
						break;
					}
					case ActionMode.Finish:
					{
						head = new byte[] { 0x95, 0x00, 0x00 };
						bytes = new byte[] { 0x00, 0x00, 0x00, 0x00 };
						break;
					}
					//case ActionMode.LockOn:
					//{
					//	head = new byte[] { 0x00, 0x00, 0x05 };
					//	bytes = new byte[] { 0x00, 0x00, 0x02, 0x00 };
					//	break;
					//}
					//case ActionMode.LockOff:
					//{
					//	head = new byte[] { 0x00, 0x00, 0x05 };
					//	bytes = new byte[] { 0x00, 0x00, 0x01, 0x00 };
					//	break;
					//}
					default: break;
				}
				highByte = bytes[0];
				lowByte = bytes[1];
				List<byte> buffer = new List<byte>(11);
				buffer.AddRange(new byte[] { 0x7F, 0x7F });
				buffer.AddRange(head);
				buffer.Add(highByte);
				buffer.Add(lowByte);
				buffer.AddRange(GeneralMethods.GetCrcResult(buffer.ToArray()));
				buffer.AddRange(new byte[] { 0x0D, 0x0A });
				result = buffer.ToArray();
			}
			this._ActionMode = ActionMode.None;
			return result;
		}

		private byte[] EncodeRestoration(byte localAddressHigh, byte localAddressLow)
		{
			var result = new List<byte>(9);
			result.AddRange(GeneralMethods._ResetInfoHeader);
			result.Add(localAddressHigh);
			result.Add(localAddressLow);
			result.Add(0x00);
			result.Add(0x01);
			result.Add(GeneralMethods.SumVerification(result.ToArray()));
			return result.ToArray();
		}

		private byte[] EncodeWriteOthers(byte localIDHigh, byte localIDLow)
		{
			List<byte> buffer = default(List<byte>);
			byte functionCode = 0x00;
			byte[] values = default(byte[]);
			switch (this._ActionMode)
			{
				case ActionMode._433:
				{
					buffer = new List<byte>(11);
					values = new byte[] { 0x10, 0x00 };
					break;
				}
				case ActionMode.HoldOn:
				{
					buffer = new List<byte>(13);
					functionCode = 0x86;
					values = new byte[] { this.HoldOn1, this.HoldOn2, this.HoldOn3, this.HoldOn4 };
					break;
				}
				case ActionMode.Zigbee:
				{
					buffer = new List<byte>(11);
					functionCode = 0x86;
					values = new byte[] { this.Zigbee1, this.Zigbee2 };
					break;
				}
				case ActionMode.LockOn:
				{
					buffer = new List<byte>(11);
					values = new byte[] { 0x02, 0x00 };
					break;
				}
				case ActionMode.LockOff:
				{
					buffer = new List<byte>(11);
					values = new byte[] { 0x01, 0x00 };
					break;
				}
				default: break;
			}
			buffer.AddRange(new byte[] { 0x7F, 0x7F });
			buffer.Add(functionCode);
			buffer.Add(localIDHigh);
			buffer.Add(localIDLow);
			buffer.AddRange(values);
			buffer.AddRange(GeneralMethods.GetCrcResult(buffer.ToArray()));
			buffer.AddRange(new byte[] { 0x0D, 0x0A });
			this._ActionMode = ActionMode.None;
			return buffer.ToArray();
		}
	}
}
