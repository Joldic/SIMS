   M S B A M L   `   `   `  ����C  ?projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:projekat.View.ModelViewprojekat.View.ModelView  5   	   '    !projekat.View.ModelView.DrugsView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:projekat.View.ModelView     5   	     � Title$  	DrugsView��5   	   $	��540��6   $	��800��6(   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DataGridXAML��5
      $
��Left=�6G   $	��Top=�6b   $	��780��6z   $	��214��6�   $��0,10,0,0q�6�   ��6*   �� *Data+ � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%�   '        �� 5      "  6   .�5      ��  � ��
 ���@�63   �� 5       � ��$ SemiBold"�63   �� 5       � ��$ 0, 0 , 1 ,2q�68   �� 5       � ��
 �   �64   5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Drug ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 130 6M   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 66   �� *Id+6M     5      $
 Name��6%   $	 130 6L   	 63   �� *Name+6L     5      $ Weight��6%   $	 130 6P   	 65   �� *Weight+6P     5      $ Category��6%   $	 130 6T   	 67   �� *
Category+6T     5      $ Quantity��6%   $	 130 6T   	 67   �� *
Quantity+6T   4  .System.Windows.Controls.DataGridTemplateColumn  5      
   CellTemplate
 5      �� 5       .R�5!      �� $��Delete��6%   -   5        .��5!   O   Delete6W   5"      5$        5'      
 5(      �� 5)      .R�5*      �� $��Update��6%   -   5        .��5*   O   Update6W   5+      5-        5/      
 50      �� 51      .R�52      �� $��Ingredients��6%   -   5        .��52   S   Ingredients6`   53      55      58      �� 59   
   $��Add new drug��6   $
��Left=�6'   $
��Bold"�6B   $��	371,0,0,0q�6T   $��Center=�6g   �� 5:   
   -   5        $��Name_tb��5:      $
��Left=�6!   $��356,293,0,0q�6<    �� TextWrapping$
 Wrap=�6Q   $�� ��6e   $	��Top=�6m   $	��120��6�   �� 5;   
   -   5        $��	Weight_tb��5;      $
��Left=�6#   $��356,334,0,0q�6>   $
 Wrap=�6S   $�� ��6g   $	��Top=�6o   $	��120��6�   �� 5<   
   -   5        $��Category_tb��5<      $
��Left=�6%   $��356,376,0,0q�6@   $
 Wrap=�6U   $�� ��6i   $	��Top=�6q   $	��120��6�   �� 5=   
   -   5        $��Quantity_tb��5=      $
��Left=�6%   $��356,425,0,0q�6@   $
 Wrap=�6U   $�� ��6i   $	��Top=�6q   $	��120��6�   �� 5>   
   $
��Name��6   $
��Left=�6   $��297,289,0,0q�6:   $	��Top=�6O   �� 5?   
   $��Weight��6   $
��Left=�6!   $��297,330,0,0q�6<   $	��Top=�6Q   �� 5@   
   $��Category��6   $
��Left=�6#   $��297,372,0,0q�6>   $	��Top=�6S   �� 5A   
   $��Quantity��6   $
��Left=�6#   $��297,421,0,0q�6>   $	��Top=�6S   �� 5B   
   -	   5        $	��Add��5B      $
��Left=�6   $��400,467,0,0q�6:   $	��Top=�6O   6g   5D      5E      