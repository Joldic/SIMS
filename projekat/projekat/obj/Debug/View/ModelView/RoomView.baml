   M S B A M L   `   `   `  ����C  ?projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:projekat.View.ModelViewprojekat.View.ModelView  5   	   &     projekat.View.ModelView.RoomView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:projekat.View.ModelView     5   	     � Title$  RoomView��5   	   $	��650��6   $	��800��6'   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DataGridXAML��5
      $��Center=�6*   $	��Top=�6G   $	��780��6_   $	��300��6k    � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%�   '        �� 5      "  6   .�5      ��  � ��
 ���@�63   �� 5       � ��$ SemiBold"�63   �� 5       � ��$ 0, 0 , 1 ,2q�68   �� 5       � ��
 �   �64   5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Room ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 130 6M   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 66   �� *Id+6M     5      $ 	Room Name��6%   $	 130 6Q   	 68   �� *Name+6Q     5      $ 	Room Type��6%   $	 130 6Q   	 68   �� *Type+6Q     5      $ Square Footage��6%   $	 130 6_   	 6=   �� *SquareFootage+6_   4  .System.Windows.Controls.DataGridTemplateColumn  5      
   CellTemplate
 5      �� 5       .R�5!      �� $��Delete��6%   -   5        .��5!   O   Delete6W   5"      5$        5&      
 5'      �� 5(      .R�5)      �� $��Update��6%   -   5        .��5)   O   Update6W   5*      5,      50      �� 51   
   $��Add room��6   $
��Left=�6#   $��362,317,0,0q�6>   $	��Top=�6S    J� RenderTransformOrigin$ 0.374,-0.642&�6k   $
��Bold"�6�   �� 52   
   -   5        $��	Room_name��52      $��Center=�6#   $��	0,360,0,0q�6@    �� TextWrapping$
 Wrap=�6S   $�� ��6g   $	��Top=�6o   $	��120��6�   �� 53   
   -   5        $��Client��53      $��Center=�6"   $��	0,395,0,0q�6?   $	��Top=�6R   $	��120��6j   ��6v   �� *	RoomTypes+�� 54   
   $
��Name��6   $
��Left=�6   $��264,352,0,0q�6:   $	��Top=�6O   $��43��6g   �� 55   
   $
��Type��6   $
��Left=�6   $��264,393,0,0q�6:   $	��Top=�6O   $��43��6g   �� 56   
   -   5         ��Name$ Square_footage��56      $��Center=�6*   $��	0,449,0,0q�6G   $
 Wrap=�6Z   $�� ��6n   $	��Top=�6v   $	��120��6�   �� 57   
   $��Square footage��6   $
��Left=�6)   $��208,445,0,0q�6D   $	��Top=�6Y   $��99��6q   �� 58   
   -   5        $
��Add ��58      $
��Left=�6    $��376,493,0,0q�6;   $	��Top=�6P   $��53��6h   $��33��6s   6   5;      5<      