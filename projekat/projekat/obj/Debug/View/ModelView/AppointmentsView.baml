   M S B A M L   `   `   `  ����C  ?projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:projekat.View.ModelViewprojekat.View.ModelView  5   	   .    (projekat.View.ModelView.AppointmentsView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:projekat.View.ModelView     5   	   -   5          �Name$  _window��5	   	    � Title$ AppointmentsView��5   	   $	��800��6"   
�������$
��1136��6B   .��5
      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DataGridXAML��5      $��Center=�6*   $	��Top=�6G   $
��1116��6_   $	��300��6l    � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%�   '        �� 5      "  6   .�5      ��  � ��
 ���@�63   �� 5       � ��$ SemiBold"�63   �� 5       � ��$ 0, 0 , 1 ,2q�68   �� 5       � ��
 �   �64   5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Appointment ID��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 95 6T   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6=   �� *Id+6T     5      $ Start��6%   $		 130 6|   
 64   �� *StartAppointment+ �� StringFormat$ dd/MM/yyyy hh:mm tt��6|     5      $	 End��6%   $		 130 6x   
 63   �� *EndAppointment+$ dd/MM/yyyy hh:mm tt��6x     5      $ Doctor Name��6%   $		 100 6Y   
 6:   �� *
DoctorName+6Y     5      $ Doctor Surname��6%   $		 100 6_   
 6=   �� *DoctorSurname+6_     5      $ Patient Username��6%   $		 100 6c   
 6?   �� *PatientUsername+6c     5       $ Patient Name��6%   $		 100 6[   
 6;   �� *PatientName+6[     5!      $ Patient Surame��6%   $		 100 6`   
 6=   �� *PatientSurname+6`     5#      $ 	Room name��6%   $	 80 6U   
 68   �� *
RoomName+6U   4  .System.Windows.Controls.DataGridTemplateColumn  5&         CellTemplate 5'      �� 5(      .R�5)      �� $��Delete��6%   -   5        .��5)   O   Delete6W   5*      5,        5.       5/      �� 50      .R�51      �� $��Update��6%   -   5        .��51   O   Update6W   52      54      5;      �� 5@   
   -   5        $��Patients��5@      $
��Left=�6#   $��472,434,0,0q�6>   $	��Top=�6S   $	��200��6k   ��5A      �� 5B      .R�5C      �� ��6    �� *
Username+5D      5F      �� 5H   
   -   5        $��Doctors��5H      $
��Left=�6#   $��472,500,0,0q�6>   $	��Top=�6S   $	��200��6k   ��5I      �� 5J      .R�5K      �� ��6    �� *
Username+5L      5N      �� 5P   
   $��	Patients:��6   $
��Left=�6$   $��413,430,0,0q�6?   $	��Top=�6T   �� 5Q   
   $��Doctors:��6   $
��Left=�6#   $��413,496,0,0q�6>   $	��Top=�6S   �� 5R   
   $��ADD NEW APPOINTMENT��6   $
��Left=�6/   $��483,392,0,0q�6J   $	��Top=�6_   $
��Bold"�6w   $	��198��6�   (  "System.Windows.Controls.DatePicker  5S   
   -   5          Name$	 DP1��5S      $��Center=�6P   $��	0,564,0,0q�6m   $	��Top=�6�   $	��192��6�   �� 5U   
   -   5         ��Name$ cboTP��5U   g   $��Center=�6   $��	0,620,0,0q�60   $	��Top=�6C   $	��192��6[   .@�5V      �� $��08:00��6   �� 5W      $��08:30��6   �� 5X      $��09:00��6   �� 5Y      $��09:30��6   �� 5Z      $��10:00��6   �� 5[      $��10:30��6   �� 5\      $��11:00��6   �� 5]      $��11:30��6   5^      �� 5_   
   -	   5        $��OK��5_      $��Center=�6   $��	0,666,0,0q�6;   $	��Top=�6N   $��36��6f   $��60��6r   6}   �� 5`   
   $��Date:��6   $
��Left=�6    $��413,570,0,0q�6;   $	��Top=�6P   $��45��6h   �� 5a   
   $��Time:��6   $
��Left=�6    $��413,616,0,0q�6;   $	��Top=�6P   $��46��6h   5h      5j      