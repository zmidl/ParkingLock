   M S B A M L   `   `   `  ���� ?  ;Demo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Demo.ViewModelsDemo.ViewModels  'clr-namespace:Demo.Views
Demo.Views  1clr-namespace:Demo.ViewModelsDemo.ViewModels  ? ;ZMCL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=*clr-namespace:ZMCL.MyControl;assembly=ZMCLZMCL.MyControl S5clr-namespace:ZMCL.MyControl.WhiteStyle;assembly=ZMCLZMCL.MyControl.WhiteStyle     Demo.Views.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1convertclr-namespace:Demo.ViewModels     *localclr-namespace:Demo.Views     3	ViewModelclr-namespace:Demo.ViewModels     @	MyControl*clr-namespace:ZMCL.MyControl;assembly=ZMCL     IMyWhite5clr-namespace:ZMCL.MyControl.WhiteStyle;assembly=ZMCL     -     �Name$  MainWindow1�� � Title$ 
MainWindow��$	��680��$	��880�� � DataContext )   #Demo.ViewModels.MainWindowViewModel   � 	Resources    TextBlockStyle1 �� 
TargetType �� Property �� Value �� EndPoint �� 
StartPoint	 � Color
 � Offset �� ScaleX �� ScaleY3  -System.Windows.Media.Effects.DropShadowEffect   Color   	Direction   ShadowDepth   Opacity  TextBlockStyle2 �� BasedOn  TextBlockStyle3  TextBlockStyle4,   &Demo.ViewModels.StringToInt32Converter  StringToInt32Converter+   %Demo.ViewModels.StringToByteConverter  StringToByteConverter.   (Demo.ViewModels.HexStringToByteConverter  HexStringToByteConverter/   )Demo.ViewModels.HexStringToByteConverter2  HexStringToByteConverter2/   )Demo.ViewModels.ByteStringToByteConverter  ByteStringToByteConverter��%1  &	        &	 7    7   &	 �    7   &	 5    7   &	 �    &	 �    &	 �    &	 �    &	 �    �� " ��.���  � �� �� $ 0.5,1&�$ 0.5,0&�.��� $	 	#FFD7C9A7��� $	 White��$
 1Q���  � ��$ 30(���  � ��$
 Bold"���  � z� V� .~��� $	 0.7Q�$	 0.8Q��� �� T� ��  � ��$ Center=���  �@J�Effect   $ Black��$ 1Q�$ 1Q�$ 10Q��� 8   " ��.���  � �� �� $ 0.5,1&�$ 0.5,0&�.��� $	 	#FFE7FFCE��$
 0.017Q�� $	 	#FF81BF37��$
 1Q��� 8   " ��.���  � �� �� $ 0.5,1&�$ 0.5,0&�.��� $	 	#FFFFF0CC��$
 0Q�� $	 	#FF985C00��$
 1Q��� 8   " ��.���  � �� �� $ 0.5,1&�$ 0.5,0&�.��� $	 	#FF59A27A��$
 0Q�� $	 	#FF007C04��$
 1Q�          .��(� $
��auto��$
��auto�� (� Stretch$
 Fill=�.���� $	��680��$	��880��.+���  �� Orientation$ Vertical=� �� Left$	 510��
 �� Top$	 280��.+�A� $��10��$��10�����	#FFBF6E00A� $��10��$��10����Z� A� $��10��$��10�����	#FFBF6E00A� $��10��$��10����Z� A� $��10��$��10�����	#FFBF6E00A� $��10��$��10����Z� A� $��10��$��10�����	#FFBF6E00A� $��10��$��10����Z� A� $��10��$��10�����	#FFBF6E00A� $��10��$��10����Z� A� $��10��$��10�����	#FFBF6E00A� $��10��$��10����Z� A� $��10��$��10�����	#FFBF6E00A� $��10��$��10����Z� A� $��10��$��10�����	#FFBF6E00A� $��10��$��10����Z� A� $��10��$��10�����	#FFBF6E00A� $��10��$��10����Z� A� $��10��$��10�����	#FFBF6E00A� $��10��$��10����Z� A� $��10��$��10�����	#FFBF6E00A� $��10��$��10����Z� A� $��10��$��10�����	#FFBF6E00A� $��10��$��10����Z� A� $��10��$��10�����	#FFBF6E00A� $��10��$��10����Z� A� $��10��$��10�����	#FFBF6E00A� $��10��$��10����Z� A� $��10��$��10�����	#FFBF6E00A� $��10��$��10����Z� A� $��10��$��10�����	#FFBF6E00A� $��10��$��10����Z� A� $��10��$��10�����	#FFBF6E00A� $��10��$��10����Z� A� $��10��$��10�����	#FFBF6E00A� $��10��$��10����Z� A� $��10��$��10�����	#FFBF6E00 J� Effect   $ Silver��$	 300Q�   
BlurRadius$ 8Q�  ZMCL.MyControl.UcTextBox     	Watermark$ 调试数据�� �� TextWrapping$
 Wrap=�$	��828��$��98��$	 156��$ 26������ *DisplayString+ �� UpdateSourceTrigger$ PropertyChanged=� 	  ZMCL.MyControl.UcTextBlock	  #��[  $��PanID��$ 26��$ 68��	  #��[  $	 110��$	 568������ *MainDataModel.Channel+$ PropertyChanged=� �� FallbackValue$ 0��	  #��[ $��通道号码��$ 24��$	 427��  $��80��$��30��$	 122��$	 427������ *ChannelConfigurationInfo+$ 0�� �� 	Converter# [ 
  ZMCL.MyControl.UcButton
  $��发送��$��14(�$��60��$��30��$	 211��$	 428������ *ConfigureCannelCommand+{��� *
IsPortOpen+	  #��[  $��通道号码��$	 566��$ 68��	  #��[  $	 110��$ 28������ *MainDataModel.PanID+$ PropertyChanged=�$ 0��	  #��[ $��	Pan地址��$ 24��$	 280��  $��80��$��30��$	 122��$	 280������ *PanIDConfigurationInfo+$
 0000��# [  �� Mode$ OneWayToSource=�
  $��60��$��30��$��发送��$��14(�$	 425��$	 480������ *ConfigureBlueToothCommand+{��� *
IsPortOpen+
  $��发送��$��14(�$��60��$��30��$	 211��$	 280������ *ConfigurePanIDCommand+{��� *
IsPortOpen+	  #��[  $��本地地址��$	 207��$ 68��	  #��[  $	 110��$	 209������ *MainDataModel.LocalAddress+$ PropertyChanged=�$ 0��	  #��[ $��本地地址��$ 24��$	 330��  $��80��$��30��$	 122��$	 330������ *LocalIDConfigurationInfo+$
 0000��# [ $ OneWayToSource=�
  $��发送��$��14(�$��60��$��30��$	 425��$	 530������ *WriteHoldOnCommand+{��� *
IsPortOpen+
  $��发送��$��14(�$��60��$��30��$	 211��$	 330������ *ConfigureLocalIDCommand+{��� *
IsPortOpen+	  #��[  $��目标地址��$	 389��$ 68��	  #��[  $	 110��$	 389������ *MainDataModel.TargetAddress+$ PropertyChanged=�$ 0��	  #��[ $��目标地址��$ 24��$	 379��  $��80��$��30��$	 122��$	 379������ *TargetIDConfigurationInfo+$
 0000��# [ $ OneWayToSource=�
  $��发送��$��14(�$��60��$��30��$	 425��$	 580������ *WriteZigbeeCommand+{��� *
IsPortOpen+
  $��发送��$��14(�$��60��$��30��$	 211��$	 379������ *ConfigureTargetIDCommand+{��� *
IsPortOpen+	  #���  $��蓝牙名称��$ 20��$	 480��  $	��105��$��30��$	 119��$	 480������ *BlueToothConfigurationInfo1+$
 TJSP��  $��70��$��30��$	 232��$	 480������ *BlueToothConfigurationInfo2+$ A��  $	��105��$��30��$	 311��$	 481������ *BlueToothConfigurationInfo3+$
 0002��	  #���  $��抬起时间��$ 20��$	 530��  $ 没车时间��$��70��$��30��$	 119��$	 530������ *	HoldOn1+# [   $ 再起一次时间��$��70��$��30��$	 195��$	 530������ *	HoldOn2+# [   $ 次数��$��50��$��30��$	 271��$	 530������ *	HoldOn3+# [   $ 蓝牙打开没车时间��$��90��$��30��$	 326��$	 530������ *	HoldOn4+# [ 	  #���  $��zigbee时间��$ 20��$	 580��  $ 多久发一次（秒）��$	��130��$��30��$	 147��$	 580������ *	Zigbee1+# [   $ 多久休眠（10ms）��$	��130��$��30��$	 286��$	 580������ *	Zigbee2+# [ 	  #��[ $��选择串口��$	 153��$ 19��	  #��[ $��	波特率��$	 380��$ 19��	  #��[ $	 450��$ 19������ *_MyBuadRate+	  #��[ $��	数据位��$	 550��$ 19��	  #��[ $	 620��$ 19������ *_MyDataBits+	  #��[ $��通道号码��$	 546��$	 429��  $��80��$��30��$	 643��$	 429������ *ChannelModificationInfo+$ 0��# [ 
  $��修改��$��14(�$��60��$��30��$	 736��$	 429������ *ModifyChannelCommand+{��� *
IsPortOpen+	  #��[ $��	Pan地址��$	 546��$	 278��  $��80��$��30��$	 643��$	 279������ *PanIDModificationInfo+$
 0000��# [ $ OneWayToSource=�
  $��修改��$��14(�$��60��$��30��$	 736��$	 278������ *ModifyPanIDCommand+{��� *
IsPortOpen+	  #��[ $��本地地址��$	 544��$	 328��  $��80��$��30��$	 643��$	 328������ *LocalIDModificationInfo+$
 0000��# [ $ OneWayToSource=�
  $��修改��$��14(�$��60��$��30��$	 736��$	 328������ *ModifyLocalIDCommand+{��� *
IsPortOpen+	  #��[ $��目标地址��$	 546��$	 380��  $��80��$��30��$	 643��$	 380������ *TargetIDModificationInfo+$
 0000��# [ $ OneWayToSource=�
  $��修改��$��14(�$��60��$��30��$	 736��$	 380������ *ModifyTargetIDInfoCommand+{��� *
IsPortOpen+
  $	��269��$��38��$��完成��$��14(�$	 147��$	 626������ *ConfigureFinishCommand+{��� *
IsPortOpen+*  $ZMCL.MyControl.WhiteStyle.MyCheckBox  -     Name$ MyCheckBox_PortSwitch��$ 31��$ 10��$��50��$	��100�� d� 	IsChecked �� *
IsPortOpen+%  ZMCL.MyControl.MyTriangleButton  $��80��$��52��$��14(�$	 755��$	 524������ *Write433Command+{��� *
IsPortOpen+  � LayoutTransform  V� .~��� �� �� ! �� Angle$
! 90.2Q�T� ���� $	��433��  $��80��$��52��$��14(�$	 673��$	 472������ *ConfigureLockOnCommand+{��� *
IsPortOpen+���� $��开锁��  $��80��$��50��$��14(�$	 669��$	 596������ *ConfigureLockOffCommand+{��� *
IsPortOpen+  V� .~��� �� �� $	! 180Q�T� ���� $��关锁��$��-52,-31,52,31q�  V� .~��� �� �� $	! 180Q�T� 
  $��显示ID��$��14(�$	��113��$��32��$	 540��$	 515��
  $��14(�$��43��$	��182��$	 811��$	 277������ *BatchModifyCommand+{��� *
IsPortOpen+.���� $ Vertical=�.+��� $	��修�����	#FFA57300$��16(��� $	��改�����	#FFA57300$��16(�
  $��倒计时2s开始��$��14(�$	��113��$��32��$	 540��$	 568��  ZMCL.MyControl.UcComboBox  -   "  Name$
" cbx1��$��90��$��42��$��14(�$	 253��$ 14������ *SerialPortNames+# �� SelectedItem# �� *SelectedPortName+$ OneWayToSource=�$ PropertyChanged=����� $ 0.5,1&�$ 0.5,0&�.��� $	 	#FFC3AA0B��$
 1Q�� $	 	#FF5F4D04��"  ZMCL.MyControl.UcGlassButton  $��查询�����	#FF0093FF$��60��$��60��$	 714��$��0q�$ 83��{��� *
IsPortOpen+���� *QueryCommand+  $��重置�����	#FF0093FF$��60��$��60��$	 714��$��0q�$ 10��{��� *
IsPortOpen+���� *ResetCommand+