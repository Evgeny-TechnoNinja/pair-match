   M S B A M L   `   `   `  ���� E  APair Match, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:PairMatch.ViewModelsPairMatch.ViewModels       PairMatch.Views.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     9
viewModels"clr-namespace:PairMatch.ViewModels       � WindowStartupLocation$  CenterScreen=� � Icon$ /Resources/icon.ico�� � Title$ Sign In��$	��400��$	��480�� � 
ResizeMode$ CanMinimize=����#72AECD
�������.��� $��20q�.+��� $��Welcome!��$	��200��$��40��$��Center=�$	��Top=�$��Center=�$��0q�
�������$��30(�$
��Bold"�A� $	��150��$	��150��$��Center=�$	��Top=�$��0,50,0,0q�
�������$��3������  �� ImageSource �� *SelectedItem.Avatar+ �� ElementName$ UsersListBox���� -   $��UsersListBox��$	��250��$	��130��$��Center=�$	��Top=�$��	0,220,0,0q�$��Center=�$��	20,5,20,5q����#D3BBAA���#46519A
�������$��3q�   ListBoxItemStyle#��[  $
��Auto=� �� SelectionMode$ Single=�����  �� DataType$ viewModels:UserViewModel��.R��� $��20(�$��20,0,0,0q����� *
Username+ � 	Resources 	 �� 
TargetType
 �� Property �� Value��%:   '��       �� "	 ��.��� 
 �@��CornerRadius$ 20���� -   $��NewUserButton��$��New User��$��75��$��30��$
��Left=�$��Bottom=�  RoundedButtonStyle#��[ �� -   $��DeleteUserButton��$��Delete User��$��75��$��30��$
��Left=�$��Bottom=�$��80,0,0,0q�#��[ {�.  �� -   $��
PlayButton��$
��Play��$��75��$��30��$
��Left=�$��Bottom=�$��	160,0,0,0q�#��[ {�.  �� -   $��CancelButton��$��Cancel��$��75��$��30��$��Right=�$��Bottom=�#��[ ���#90333C