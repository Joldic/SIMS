   M S B A M L   `   `   `  ����C  ?projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:projekat.View.ModelViewprojekat.View.ModelView  5   	   ,    &projekat.View.ModelView.OperationsView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:projekat.View.ModelView     5   	     � Title$  OperationsView��5   	   $
��1000��6    $
��1200��6.   .��5	      � $��
0,0,0,-192q�6   .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DataGridXAML��5
      $��Center=�6*   $	��Top=�6G   $
��1116��6_   $	��300��6l    � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%�   '        �� 5      "  6   .�5      ��  � ��
 ���@�63   �� 5       � ��$ SemiBold"�63   �� 5       � ��$ 0, 0 , 1 ,2q�68   �� 5       � ��
 �   �64   5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Appointment ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 95 6T   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6=   �� *Id+6T     5      $ Start��6%   $	 130 6Z   	 64   �� *StartAppointment+6Z     5      $	 End��6%   $	 130 6V   	 63   �� *EndAppointment+6V     5      $ Doctor Name��6%   $	 100 6Y   	 6:   �� *
DoctorName+6Y     5      $ Doctor Surname��6%   $	 100 6_   	 6=   �� *DoctorSurname+6_     5      $ Patient Name��6%   $	 100 6_   	 6;   �� *PatientUsername+6_     5      $ Patient Name��6%   $	 100 6[   	 6;   �� *PatientName+6[     5       $ Patient Surame��6%   $	 100 6`   	 6=   �� *PatientSurname+6`     5"      $ 	Room name��6%   $ 80 6U   	 68   �� *
RoomName+6U   4  .System.Windows.Controls.DataGridTemplateColumn  5%      
   CellTemplate
 5&      �� 5'      .R�5(      �� $��Delete��6%   -   5        .��5(   O   Delete6W   5)      5+        5-      
 5.      �� 5/      .R�50      �� $��Update��6%   -   5        .��50   O   Update6W   51      53      5:      �� 5;   
   -   5        $��Patients��5;      $
��Left=�6#   $��483,434,0,0q�6>   $	��Top=�6S   $	��189��6k   ��5<      �� 5=      .R�5>      �� ��6    �� *
Username+5?      5A      �� 5C   
   -   5        $��Doctors��5C      $
��Left=�6#   $��483,500,0,0q�6>   $	��Top=�6S   $	��189��6k   ��5D      �� 5E      .R�5F      �� ��6    �� *
Username+5G      5I      �� 5K   
   $��	Patients:��6   $
��Left=�6$   $��413,430,0,0q�6?   $	��Top=�6T   �� 5L   
   $��Doctors:��6   $
��Left=�6#   $��413,496,0,0q�6>   $	��Top=�6S   �� 5M   
   $��ADD NEW OPERATION��6   $
��Left=�6-   $��483,392,0,0q�6H   $	��Top=�6]   $
��Bold"�6u   $	��198��6�   (  "System.Windows.Controls.DatePicker  5N   
   -   5          Name$	 DP1��5N      $
��Left=�6P   $��480,564,0,0q�6k   $	��Top=�6�   $	��192��6�   �� 5P   
   -   5         ��Name$ cboTP��5P   g   $
��Left=�6   $��483,620,0,0q�6.   $	��Top=�6C   $	��189��6[   .@�5Q      �� $��08:00��6   �� 5R      $��08:30��6   �� 5S      $��09:00��6   �� 5T      $��09:30��6   �� 5U      $��10:00��6   �� 5V      $��10:30��6   �� 5W      $��11:00��6   �� 5X      $��11:30��6   5Y      �� 5Z   
   -   5        $��OK��5Z      $
��Left=�6   $��542,717,0,0q�69   $	��Top=�6N   $��36��6f   $��60��6r   6}   �� 5[   
   $��Date:��6   $
��Left=�6    $��413,570,0,0q�6;   $	��Top=�6P   $��45��6h   �� 5\   
   $��Start Time:��6   $
��Left=�6&   $��396,616,0,0q�6A   $	��Top=�6V   $��63��6n   �� 5]   
   -	   5        $ 
cboTP_Copy��5]   g   $
��Left=�6   $��483,672,0,0q�6.   $	��Top=�6C   $	��192��6[   .@�5^      �� $��08:00��6   �� 5_      $��08:30��6   �� 5`      $��09:00��6   �� 5a      $��09:30��6   �� 5b      $��10:00��6   �� 5c      $��10:30��6   �� 5d      $��11:00��6   �� 5e      $��11:30��6   5f      �� 5g   
   $��	End Time:��6   $
��Left=�6$   $��396,670,0,0q�6?   $	��Top=�6T   $��67��6l    J� RenderTransformOrigin$ 0.804,3.045&�6w   5h      5i      