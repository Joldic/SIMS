   M S B A M L   `   `   `  ����C  ?projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:projekat.View.ModelViewprojekat.View.ModelView  5   	   +    %projekat.View.ModelView.EquipmentView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:projekat.View.ModelView     5   	     � Title$  EquipmentView��5   	   $	��450��6   $	��800��6,   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DataGridXAML��5
      $��Center=�6G   $	��Top=�6d   $	��780��6|   $	��300��6�   $��0,92,0,0q�6�   ��6*   �� *Data+ � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%�   '        �� 5      "  6   .�5      ��  � ��
 ���@�63   �� 5       � ��$ SemiBold"�63   �� 5       � ��$ 0, 0 , 1 ,2q�68   �� 5       � ��
 �   �64   5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Equipment ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 130 6R   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6;   �� *Id+6R     5      $ Quantity��6%   $	 130 6T   	 67   �� *
Quantity+6T     5      $ Equipment Name��6%   $	 130 6V   	 6=   �� *Name+6V     5      $ Equipment Type��6%   $	 130 6V   	 6=   �� *Type+6V   4  .System.Windows.Controls.DataGridTemplateColumn  5      
   CellTemplate
 5      �� 5      .R�5       �� $��Delete��6%   -   5        .��5    O   Delete6W   5!      5#      5&      �� 5'   
   -   5        $��Name_tb��5'      $
��Left=�6!   $��	21,25,0,0q�6<    �� TextWrapping$
 Wrap=�6O   $�� ��6c   $	��Top=�6k   $	��120��6�   �� 5(   
   -   5        $��Search��5(      $
��Left=�6"   $��
177,20,0,0q�6=   $	��Top=�6Q   $��54��6i   $��28��6t   6�   �� 5)   
   -   5        $��Type_tb��5)      $
��Left=�6!   $��
318,25,0,0q�6<   $
 Wrap=�6P   $�� ��6d   $	��Top=�6l   $	��120��6�   �� 5*   
   -   5        $��Search by type��5*      $
��Left=�6*   $��
472,24,0,0q�6E   $	��Top=�6Y    J� RenderTransformOrigin$ 0.234,-0.053&�6q   $��86��6�   $��24��6�   6�   5-      5.      