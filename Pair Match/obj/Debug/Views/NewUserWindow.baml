   M S B A M L   `   `   `  ����E  APair Match, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:PairMatch.ViewModelsPairMatch.ViewModels  5   	   #    PairMatch.Views.NewUserWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9
viewModels"clr-namespace:PairMatch.ViewModels     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Topmost .  � Title$ New User��5	   	   $	��330��5
   	   $	��360��6    � 
ResizeMode$ NoResize=�6"   ���#72AECD
������� � WindowStyle$ 
ToolWindow=�5   	    � ShowInTaskbar .  .��5      � .+�5   
   A� $	��150��6   $	��150��6   $��Center=�5      $	��Top=�6/   $��0,20,0,0q�6G   
�������$��3��5   !   ��5      �� 5       �� ImageSource 6   �� *Avatar+5      �� 5   
   -   5        $��
LeftButton��5      $��30��5      $��30��6   $��Center=�5      $	��Top=�6.   $��-200,80,0,0q�6F      ArrowButtonStyle#��[  5      .��5      �� $��/Resources/left-arrow.png��6   $��30��5       $��30��6   $��-1,0,0,0q�5!      5"      �� 5$   
   -   5        $��RightButton��5$      $��30��5%      $��30��6   $��Center=�5&      $	��Top=�6.   $��
200,80,0,0q�6F   #��[  5'      .��5*      �� $ ��/Resources/right-arrow.png��6   $��30��5+      $��30��6   $��0,0,-1,0q�5,      6(   5-      �� 5/   
   -   5        $��UsernameTextBox��5/      $	��200��50      $��30��6   $��Center=�51      $	��Top=�6/   $��	0,190,0,0q�6G   $��Center=�52      $��Center=�53      $��5q�64   
������� �� SelectionBrush �	#FF72AECD.��54   ?   ��56      �� 57       �� Path$ Username�6   	 �� UpdateSourceTrigger$	 PropertyChanged=�6*   
 �� ValidationRules
 58      1  +PairMatch.ViewModels.UsernameValidationRule  59      ,  &System.Windows.Controls.ValidationRule   ValidationStep$ RawProposedValue=�6<   5;      .��5<       � 	Resources 5>       �� 
TargetType �� Property �� Value��%^   '��       �� 5?      " ��6   .�5@      ��  �@��CornerRadius$ 5��65   5A      5B      .��6!    =� ErrorTemplate 5D      �� 5E      .R�5F      �� .+�5G      ��  ��Name$ UsernameTextBox��64   �� 5H      $	��200��5I   $   $
��Wrap=�60   $��0,5,0,0q�5J   $   
���  ��  TextBlockStyle#��[ 5L   $   ��5H   $   �� *ErrorContent+5L   $   5M      5N      .��5O   (   5P      �� 5R   
   $��Username��6   $��Center=�5S      $	��Top=�61   $��	0,197,0,0q�6I   
������� J� IsHitTestVisible .  ��5V      �� 5W      " ��6   .�5X      ��  � y�$ 	Collapsed=�63    �� Triggers 5Y      �� 5Z       �� Binding 6&   �� *Text+ �� ElementName$ UsernameTextBox�� �� Value  6\   .a�5[      ��  � y�$ Visible=�6;   5\      5^      5`      �� 5b   
   -   5        $��Create��5b      $��75��5c      $��30��6   $
��Left=�5d      $��Bottom=�6,   $��	75,0,0,20q�6G     RoundedButtonStyle#���  5e      5f      �� 5h   
   -   5        $��Cancel��5h      $��75��5i      $��30��6   $��Right=�5j      $��Bottom=�6-   $��	0,0,75,20q�6H   #��[ 5k      ���#90333C5l      5n      5o      