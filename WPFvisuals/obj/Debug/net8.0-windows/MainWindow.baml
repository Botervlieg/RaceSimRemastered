   M S B A M L   `   `   `  ����E  AWPFvisuals, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WPFvisuals
WPFvisuals  5   	   E AController, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:Controller;assembly=Controller
Controller 5   	       WPFvisuals.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:WPFvisuals     5   	   C
Controller,clr-namespace:Controller;assembly=Controller     5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)    � DataContext 5
      &   Controller.DataContextStatistics  5   
   .��5      � .+�5   
   ]� $��False��6   $��20��6*   $	��Top=�66   $
��2560��6N   $��2��6[   .+�5      o� $	��NaN��6   $	��Top=�6   $��20��64   .@�5      m� $
��Menu��6   .@�5      m� -   5        $��Competition Information��5      6@   m� 5      -   5        $��Close Program��5      66   5      5      5      �� 5   
   -   5         ��Name$ 	TrackName��5      $��0,25,521,307q�6B   ��6#   �� *
Track.Name+6B   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DataGrid��5         MinColumnWidth$	 100Q�6%   $	��350��6:      AutoGenerateColumns$ False��6g   $��82,42,226,42q�6�   ��6G   �� *	Drivers+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Name+  5      $ Round��6%    64   �� *Lap+  5      $ Speed��6%    64   �� *Equipment.Speed+  5      $ Distance��6%    67   �� *TotalDistance+  5      $ 	IsCrashed��6%    68   �� *Equipment.IsBroken+5         5!   
   -   5        $ 	DataGrid2��5!      $	 150Q�6&   $	��150��6;   $	��350��6G   $ False��6u   $��604,42,46,42q�6�   ��6T   �� *
Sections+ 5"        5#      $ SectionTypes��6%    6;   �� *SectionType+5%      5&      5'      