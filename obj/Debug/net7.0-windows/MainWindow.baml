   M S B A M L   `   `   `  ����P  LCPSC440_F2023_Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:CPSC440_F2023_ProjectCPSC440_F2023_Project  5   	   Q-clr-namespace:CPSC440_F2023_Project.ViewModelCPSC440_F2023_Project.ViewModel  5   	   p lDotNetProjects.DataVisualization.Toolkit, Version=6.1.94.0, Culture=neutral, PublicKeyToken=79778c5f2eed289b�rclr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=DotNetProjects.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting 5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 6�   &     CPSC440_F2023_Project.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:CPSC440_F2023_Project     5   	   Alocalvm-clr-namespace:CPSC440_F2023_Project.ViewModel     5   	   �chartingToolkitrclr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=DotNetProjects.DataVisualization.Toolkit     5   	   6sys&clr-namespace:System;assembly=mscorlib     6�     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � DataContext 5      6  0CPSC440_F2023_Project.ViewModel.StudentViewModel  5   
   .��5      �� .+�5   
   >  8System.Windows.Controls.DataVisualization.Charting.Chart  -   5        $��ScoresChart��5          Title$ Students Score��63   $��1��6K   $��2��6\   $	��217��6j   $	��756��6w   $��Center=�6�   $	��Top=�6�      Axes 5      E  ?System.Windows.Controls.DataVisualization.Charting.CategoryAxis  =  7System.Windows.Controls.DataVisualization.Charting.Axis   Orientation$ X=�6/   D  >System.Windows.Controls.DataVisualization.Charting.DisplayAxis   ShowGridLines$
 True��6?   C  =System.Windows.Controls.DataVisualization.Charting.LinearAxis  5         Title$ Student GPA��6-   D  >System.Windows.Controls.DataVisualization.Charting.NumericAxis   Maximum�  �System.Windows.Controls.DataVisualization.Charting.NullableConverter`1[[System.Double, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]$ 5 5   1      Minimum$ 0 5   1   $ Y=�5   1   $
 True��5   1   	   Series.	 5      E	  ?System.Windows.Controls.DataVisualization.Charting.SplineSeries	  H
  BSystem.Windows.Controls.DataVisualization.Charting.DataPointSeries
 
  DependentValuePath$
 Value��6+    
  IndependentValuePath$	 Key��5       
  IsSelectionEnabled$
 True��5       
  SelectedItem 5      �� *SelectedKey+ �� Mode$ TwoWay=� 
  ItemsSource 5      �� *StudentGPAData+5!      �� 5"   
   $��Student ID : ��6    �� Left$ 32��6(   
 �� Top$	 396��69   �� 5#   
   $	 107��6    �� TextWrapping$
 Wrap=�6$   $	 400��68   $	��120��6I   ��6U   �� *	StudentID+�� 5$   
   $��GPA : ��6   $	 300��6!   $	 396��63   �� 5%   
   $	 340��6   $
 Wrap=�6$   $	 400��68   $	��120��6I    J� RenderTransformOrigin$ 0.162,0.865&�6q   ��6U   �� *
StudentGPA+6q   �� 5&   
   $	 540��6   $	 400��6#   $��80��64   $
��Exit��6?   ��6N   �� *ExitCommand+&   System.Windows.Controls.DataGrid  5'   
   -   5        $��StudentDataGrid��5'      $	��151��6`   $	��746��6m   $
��Left=�6y   $	 222��6�   $��Center=�6�   $ 10��6�   ��6*   �� *studentDataTable+$ TwoWay=�6�   5(      5)      