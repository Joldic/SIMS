   M S B A M L   `   `   `  ����C  ?projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:projekat.View.ModelViewprojekat.View.ModelView  5   	   +    %projekat.View.ModelView.AllergensView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:projekat.View.ModelView     5   	     � Title$  AllergensView��5   	   $	��450��6   $	��800��6,   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DataGridXAML��5
      $��Center=�6*   $	��Top=�6G   $	��800��6_   $	��217��6k    � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%�   '        �� 5      "  6   .�5      ��  � ��
 ���@�63   �� 5       � ��$ SemiBold"�63   �� 5       � ��$ 0, 0 , 1 ,2q�68   �� 5       � ��
 �   �64   5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$  Patient ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6X   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6:   �� *	PatientId+6X     5      $ Allergen ID��6%   $ 95 6Y   	 6:   �� *
AllergenId+6Y     5      $  Allergen Name��6%   $	 100 6^   	 6=   �� *AllergenName+6^   4  .System.Windows.Controls.DataGridTemplateColumn  5      
   CellTemplate
 5      �� 5      .R�5      �� $��Delete��6%   -   5        .��5   O   Delete6W   5       5"      5%      �� 5&   
   -   5        $��Names��5&      $
��Left=�6    $��321,281,0,0q�6;   $	��Top=�6P   $	��120��6h   ��5'      �� 5(      .R�5)      �� ��6    �� *Name+5*      5,      �� 5.   
   $��Allergen Name��6   $
��Left=�6(   $��216,279,0,0q�6C   $	��Top=�6X    J� RenderTransformOrigin$ -0.211,0.451&�6p   �� 5/   
   -   5        $��OK��5/      $
��Left=�6   $��358,323,0,0q�69   $	��Top=�6N   $��25��6f   $��46��6r   $ 0.374,-0.689&�6}   6�   �� 50   
   $��ADD ALLERGENS��6   $
��Left=�6(   $��328,238,0,0q�6C   $	��Top=�6X   $
��Bold"�6p   51      52      