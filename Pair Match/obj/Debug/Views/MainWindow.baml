   M S B A M L   `   `   `  ����E  APair Match, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:PairMatch.ViewModelsPairMatch.ViewModels  5   	        PairMatch.Views.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9
viewModels"clr-namespace:PairMatch.ViewModels     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Icon$ /Resources/icon.ico��5	   	    � Title$ Sign In��6$   $	��400��5
   	   $	��480��6    � 
ResizeMode$ CanMinimize=�6"   ���#72AECD
�������.��5      � $��20q�6   .+�5   
   �� $��Welcome!��6   $	��200��5      $��40��6   $��Center=�5      $	��Top=�6-   $��Center=�5      $��0q�64   
�������$��30(�5      $
��Bold"�6   A� 5   
   $	��150��6   $	��150��6   $��Center=�5      $	��Top=�6/   $��0,50,0,0q�6G   
�������$��3��5   !   ��5      �� 5       �� ImageSource 6   �� *SelectedItem.Avatar+ �� ElementName$ UsersListBox��5      �� 5   
   -   5        $��UsersListBox��5      $	��250��5       $	��130��6   $��Center=�5!      $	��Top=�6/   $��	0,220,0,0q�6G   $��Center=�5"      $��	20,5,20,5q�66   ���#D3BBAA���#46519A
�������$��3q�5$   &   $
��Auto=�5%         ListBoxItemStyle#��[  5&       �� SelectionMode$ Single=�5'      ��5*      �� 5+       �� DataType$ viewModels:UserViewModel��6   .R�5,      �� $��20(�6:   $��20,0,0,0q�6H   ��6    �� *
Username+6H   5-       � 	Resources 50      	 �� 
TargetType
 �� Property �� Value �� 
TargetType �Name J� SnapsToDevicePixels��%�  '��       '�� U     7���� 51      "	 ��6   .�52      �� 
 �@��CornerRadius$ 20��65   53      �� 55      "	 ��6   .�56      �� 
 � ��
 ���� 63   �� 57      
 � ��8   63   �� 58      
 � �� 59      �� 5:      " ��6.   .R�5;   "   � $ Bg��6'   #��z��63    . .+�5<   &   �� $��3��6-   $��Center=�67   
�������6T   5=   #   5>      5@      5A      5B      5C      �� 5L   
   -   5        $��NewUserButton��5L      $��New User��5M      $��75��5N      $��30��6   $
��Left=�5O      $��Bottom=�6,     RoundedButtonStyle#��[ 5P      5Q      �� 5S   
   -   5        $��DeleteUserButton��5S      $��Delete User��5T      $��75��5U      $��30��6   $
��Left=�5V      $��Bottom=�6,   $��80,0,0,0q�6G   #��[ 5W      {�.  5Y      �� 5[   
   -   5        $��
PlayButton��5[      $
��Play��5\      $��75��5]      $��30��6   $
��Left=�5^      $��Bottom=�6,   $��	160,0,0,0q�6G   #��[ 5_      {�.  5a      �� 5c   
   -   5        $��CancelButton��5c      $��Cancel��5d      $��75��5e      $��30��6   $��Right=�5f      $��Bottom=�6-   #��[ 5g      ���#90333C5h      5j      5k      