   M S B A M L   `   `   `  ���� E  APair Match, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:PairMatch.ViewModelsPairMatch.ViewModels  #    PairMatch.Views.NewUserWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     9
viewModels"clr-namespace:PairMatch.ViewModels       � WindowStartupLocation$  CenterScreen=� � Topmost .  � Title$ New User��$	��330��$	��360�� � 
ResizeMode$ NoResize=����#72AECD
������� � WindowStyle$ 
ToolWindow=� � ShowInTaskbar .  .��� .+�A� $	��150��$	��150��$��Center=�$	��Top=�$��0,20,0,0q�
�������$��3������  �� ImageSource �� *Avatar+�� -   $��
LeftButton��$��30��$��30��$��Center=�$	��Top=�$��-200,80,0,0q�   ArrowButtonStyle#��[  .���� $��/Resources/left-arrow.png��$��30��$��30��$��-1,0,0,0q��� -   $��RightButton��$��30��$��30��$��Center=�$	��Top=�$��
200,80,0,0q�#��[  .���� $ ��/Resources/right-arrow.png��$��30��$��30��$��0,0,-1,0q��� -   $��UsernameTextBox��$	��200��$��30��$��Center=�$	��Top=�$��	0,190,0,0q�$��Center=�$��Center=�$��5q�
������� �� SelectionBrush �	#FF72AECD.������  �� Path$ Username�	 �� UpdateSourceTrigger$	 PropertyChanged=�
 �� ValidationRules
 1  +PairMatch.ViewModels.UsernameValidationRule  ,  &System.Windows.Controls.ValidationRule   ValidationStep$ RawProposedValue=�.�� � 	Resources  �� 
TargetType �� Property �� Value��%9   '��       �� " ��.���  �@��CornerRadius$ 5��.�� =� ErrorTemplate �� .R��� .+���  ��Name$ UsernameTextBox���� $	��200��$
��Wrap=�$��0,5,0,0q�
���  ��  TextBlockStyle#��[ ���� *ErrorContent+.���� $��Username��$��Center=�$	��Top=�$��	0,197,0,0q�
������� J� IsHitTestVisible .  ���� " ��.���  � y�$ 	Collapsed=� �� Triggers ��  �� Binding �� *Text+ �� ElementName$ UsernameTextBox�� �� Value  .a���  � y�$ Visible=��� -   $��Create��$��75��$��30��$
��Left=�$��Bottom=�$��	75,0,0,20q�  RoundedButtonStyle#���  �� -   $��Cancel��$��75��$��30��$��Right=�$��Bottom=�$��	0,0,75,20q�#��[ ���#90333C