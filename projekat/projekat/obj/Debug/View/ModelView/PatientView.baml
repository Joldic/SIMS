   M S B A M L   `   `   `  ����C  ?projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:projekat.View.ModelViewprojekat.View.ModelView  5   	   )    #projekat.View.ModelView.PatientView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:projekat.View.ModelView     5   	     � Title$  PatientView��5   	   $	��800��6   $
��1000��6*   .��5	      � $��
0,0,0,-125q�6   .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DataGridXAML��5
      $
��Left=�6*   $	��Top=�6E   $
��1116��6]   $	��300��6j    � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%�   '        �� 5      "  6   .�5      ��  � ��
 ���@�63   �� 5       � ��$ SemiBold"�63   �� 5       � ��$ 0, 0 , 1 ,2q�68   �� 5       � ��
 �   �64   5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Patient ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 95 6P   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 69   �� *Id+6P     5      $  Patient Name��6%   $	 100 6U   	 6<   �� *Name+6U     5      $  Patient Surame��6%   $	 100 6Z   	 6>   �� *	Surname+6Z     5      $ 	 Username��6%   $	 100 6U   	 68   �� *
Username+6U     5      $  DateOfBirth��6%   $	 100 6[   	 6;   �� *DateOfBirth+6[     5      $  Adress��6%   $	 100 6Q   	 66   �� *Adress+6Q     5      $  Email��6%   $	 100 6O   	 65   �� *Email+6O     5      $  Gender��6%   $	 100 6Q   	 66   �� *Gender+6Q   4  .System.Windows.Controls.DataGridTemplateColumn  5       
   CellTemplate
 5!      �� 5"      .R�5#      �� $��Delete��6%   -   5        .��5#   O   Delete6W   5$      5&        5(      
 5)      �� 5*      .R�5+      �� $��Update��6%   -   5        .��5+   O   Update6W   5,      5.        50      
 51      �� 52      .R�53      �� $��	Allergens��6%   -   5        .��53   U   Show Allergens6e   54      56      5<      �� 5>   
   -   5        $
��Name��5>      $��Center=�6   $��	0,372,0,0q�6;    �� TextWrapping$
 Wrap=�6N   $�� ��6b   $	��Top=�6j   $	��120��6�   �� 5?   
   -   5        $��Surname��5?      $��Center=�6!   $��	0,425,0,0q�6>   $
 Wrap=�6Q   $�� ��6e   $	��Top=�6m   $	��120��6�   �� 5@   
   -   5        $��Adress��5@      $��Center=�6    $��	0,610,0,0q�6=   $
 Wrap=�6P   $�� ��6d   $	��Top=�6l   $	��120��6�   �� 5A   
   $��Surname��6   $
��Left=�6"   $��254,421,0,0q�6=   $	��Top=�6R   �� 5B   
   $��DateOfBirth��6   $
��Left=�6&   $��236,472,0,0q�6A   $	��Top=�6V   �� 5C   
   $��Adress��6   $
��Left=�6!   $��265,606,0,0q�6<   $	��Top=�6Q   (  "System.Windows.Controls.DatePicker  5D   
   -   5          Name$	 DP1��5D      $��Center=�6P   $��	0,472,0,0q�6m   $	��Top=�6�   $	��120��6�   �� 5E   
   -	   5        $��Client��5E      $��Center=�6!   $��	0,568,0,0q�6>   $	��Top=�6Q   $	��120��6i   ��6u   �� *	Genders+�� 5F   
   $��Gender��6   $
��Left=�6!   $��263,567,0,0q�6<   $	��Top=�6Q    J� RenderTransformOrigin$ 0.476,8.739&�6i   �� 5G   
   $��            ADD PATIENT��6   $��Center=�62   $��	0,328,0,0q�6O   $	��Top=�6b   $	��182��6z   $
��Bold"�6�   �� 5H   
   -
   5        $��OK��5H      $��Center=�6   $��	0,647,0,0q�6;   $	��Top=�6N   $��30��6f   $��62��6r   $ 0.578,1.289&�6�   �� 5I   
   -   5        $��Email��5I      $��Center=�6   $��	0,526,0,0q�6<   $
 Wrap=�6O   $�� ��6c   $	��Top=�6k   $	��120��6�   $ 0.507,11.041&�6�   �� 5J   
   $��Email��6   $
��Left=�6    $��265,526,0,0q�6;   $	��Top=�6P   �� 5K   
   $
��Name��6   $
��Left=�6   $��263,372,0,0q�6:   $	��Top=�6O   5L      5M      