   M S B A M L   `   `   `  ����C  ?projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:projekat.View.Dialogsprojekat.View.Dialogs  5   	   /    )projekat.View.Dialogs.EquipmentRelocation   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:projekat.View.Dialogs     5   	     � Title$  EquipmentRelocation��5   	   $	��450��6%   $	��800��62   .��5	      �  J� RenderTransformOrigin$ 0.505,0.636&�6   .+�5
   
   �� -   5        $��	Quantityy��5
      $��Center=�6#   $��	0,107,0,0q�6@    �� TextWrapping$
 Wrap=�6S   $�� ��6g   $	��Top=�6o   $	��120��6�   �� 5   
   $��Equipment name��6   $��Center=�6)   $��0,27,0,0q�6F   $	��Top=�6X   �� 5   
   $��Quantity��6   $��Center=�6#   $��0,81,0,0q�6@   $	��Top=�6R   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DataGridXAML��5      $��Center=�6*   $	��Top=�6G   $	��590��6_   $	��193��6k   $��	0,217,0,0q�6x    � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%�   '        �� 5      "  6   .�5      ��  � ��
 ���@�63   �� 5       � ��$ SemiBold"�63   �� 5       � ��$ 0, 0 , 1 ,2q�68   �� 5       � ��
 �   �64   5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Room Id��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 100 6v   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *RoomId+ �� UpdateSourceTrigger$ PropertyChanged=�6v     5      $	 	Room Name��6%   $	
 100 6z    68   �� *
RoomName+$ PropertyChanged=�6z     5      $	 	Room Type��6%   $	
 100 6v    68   �� *Type+$ PropertyChanged=�6v     5      $	 Equipment Id��6%   $	
 100 6�    6;   �� *EquipmentId+$ PropertyChanged=�6�     5      $	 Equipment Name��6%   $	
 100 6�    6=   �� *EquipmentName+$ PropertyChanged=�6�     5       $	 Quantity��6%   $	
 100 6y    67   �� *
Quantity+$ PropertyChanged=�6y   5%      �� 5&   
   -   5        $
��Show��5&      $
��Left=�6    $��504,105,0,0q�6;   $	��Top=�6P   $��61��6h   6s   �� 5'   
   -   5        $��RoomFrom��5'      $��	Room from��6    $
��Left=�64   $��262,146,0,0q�6O   $	��Top=�6d   $��23��6|   �� 5(   
   -   5        $��RoomTo��5(      $��    Room to��6   $
��Left=�64   $��262,169,0,0q�6O   $	��Top=�6d   �� 5)   
   -   5        $��Transfer��5)      $
��Left=�6$   $��504,172,0,0q�6?   $	��Top=�6T   $��61��6l   6w   �� 5*   
   -   5        $��Equipment_name_combo��5*      $��Center=�6/   $��0,56,0,0q�6L   $	��Top=�6^   $	��120��6v   $��20��6�   ��5+      �� 5,      .R�5-      �� ��6    �� *Name+5.      50      �� 52   
   -   5        $��	Room_from��52      $��Center=�6$   $��	0,148,0,0q�6A   $	��Top=�6T   $	��120��6l   ��53      �� 54      .R�55      �� ��6    �� *Name+56      58      �� 59   
   -	   5        $��Room_to��59      $��Center=�6"   $��	0,182,0,0q�6?   $	��Top=�6R   $	��120��6j   ��5:      �� 5;      .R�5<      �� ��6    �� *Name+5=      5?      5@      5A      