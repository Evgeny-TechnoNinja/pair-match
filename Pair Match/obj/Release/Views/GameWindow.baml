   M S B A M L   `   `   `  ���� E  APair Match, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:PairMatch	PairMatch  ;"clr-namespace:PairMatch.ViewModelsPairMatch.ViewModels       PairMatch.Views.GameWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -	pairMatchclr-namespace:PairMatch     9
viewModels"clr-namespace:PairMatch.ViewModels       � WindowStartupLocation$  CenterScreen=� � Icon$ /Resources/icon.ico�� � Title$ 
Pair Match��$	��400��$	��470�� � 
ResizeMode$ CanMinimize=����#72AECD
������� � 	Resources    CardFrontTemplate �� DataType  CardBackTemplate  FlipItemTemplate '�Name '� Camera � Position	 � LookDirection
 =� FieldOfView g� Content �� Color t� 	Direction � Geometry k� TriangleIndices k� TextureCoordinates k� 	Positions � Material u� Brush !� Visual �� ElementName � BackMaterial �� RelativeTransform �� ScaleX �� CenterX j� 	Transform �� Rotation �� Axis �� Angle ��Name � Triggers  :� RoutedEvent! �� 
TargetName" �� TargetProperty# R� KeyTime  System.Windows.Visibility$   Visible% R� Value&   Hidden	' W� To( g� Duration) g� 	BeginTime	* 6� To+ 6� From, g� AutoReverse- g� DecelerationRatio. W� From/ g� AccelerationRatio0 J� Opacity��%U  &	        &	 R     &	 �     7  7   �� $ viewModels:CardViewModel��.R��� $��5,5,5,5q����� *
FrontImage+�� $ viewModels:CardViewModel��.R��� $��5,5,5,5q����� *	BackImage+�� .R�� $	��100��$	��100��.+�'� $ 
ViewPort3D��$��0��$y�Hidden=� =� 
Camera��$ 0,0,0.51�$	 0,0,-15�$
 90Q�x�g�  h� .��t� $
 #444��$ 0,0,-15��� $
 #BBB��g�  �  k�  �      �   5 �   �^���^�� � �^�� �  � �^�� �  u�  !�  �� $ 	FrontHost�� u�  !�  �� $ BackHost�� �� $ -1Q�$	 0.5Q� ��  �� 
Rotate��$ 0,3,05�$ 0Q��� $ FrontWrapper��._��� $ 	FrontHost��
������  :� $  Grid.MouseDown��.[��� .���� .��T� $! 
ViewPort3D��$" 
Visibility�..�i� $# 0:0:0��#% Z$ i� $# 0:0:1.1��#% Z& T� $! BackWrapper��$" 
Visibility�..�i� $# 0:0:1��#% Z$ T� $! FrontWrapper��$" 
Visibility�..�i� $# 0:0:0.05��#% Z& W� $' 0X�$( 0:0:0.05D�$! FrontWrapper��$" Opacity�W� $) 0:0:1.05X�$( 0:0:0.05D�$' 1X�$! BackWrapper��$" Opacity�6� $* 0,0,1.1X�$+ 0,0,0.5X�$) 0:0:0.05X�$( 0:0:0.5D�, . $	- 0.3Q�$! Camera��$"" (PerspectiveCamera.Position)�W� $. 0X�$	' 180X�$	/ 0.3Q�$	- 0.3Q�$) 0:0:0.05X�$( 0:0:1D�$! Rotate��$" Angle�._��� 8��  ���� �� $ BackWrapper��$��0��$y�Hidden=�$0 0Q�._��� $ BackHost��
������  :� $  Grid.MouseDown��.[��� .���� .��T� $! 
ViewPort3D��$" 
Visibility�..�i� $# 0:0:0��#% Z$ i� $# 0:0:1.1��#% Z& T� $! FrontWrapper��$" 
Visibility�..�i� $# 0:0:1��#% Z$ T� $! BackWrapper��$" 
Visibility�..�i� $# 0:0:0.05��#% Z& W� $' 0X�$( 0:0:0.05D�$! BackWrapper��$" Opacity�W� $) 0:0:1.05X�$( 0:0:0.05D�$! FrontWrapper��$" Opacity�6� $* 0,0,1.1X�$+ 0,0,0.5X�$) 0:0:0.05X�$( 0:0:0.5D�, . $	- 0.3Q�$! Camera��$"" (PerspectiveCamera.Position)�W� $	. 180X�$	' 360X�$	/ 0.3Q�$	- 0.3Q�$) 0:0:0.05X�$( 0:0:1D�$! Rotate��$" Angle�._��� 8�� ���� 1 J� CommandBindings1 )  #System.Windows.Input.CommandBinding  -   2   Command$2 ApplicationCommands.New��  -   $)2 #pairMatch:CustomCommands.Statistics��  -   $#2 pairMatch:CustomCommands.Exit��.��� .+�o� $	��380��$��25��$��Center=�$	��Top=�$��0,5,0,0q����#6498B3.@�m� $��_File��$��40��$��25��
�������.@�m� $��	_New Game��$��20�����#6498B33 m� Command$3 ApplicationCommands.New��m� $��_Statistics��$��20�����#6498B3$)3 #pairMatch:CustomCommands.Statistics���� m� $��_Exit��$��20�����#6498B3$#3 pairMatch:CustomCommands.Exit��m� $��_Options��$��65��$��25��
�������.@�m� -   $��StandardGameMenuItem��$��	_Standard��$��22�����#6498B34 m� IsCheckable4 . 5 m� StaysOpenOnClick5 . 6 m� 	IsChecked6 �� *StandardGame+7 �� Mode$7 TwoWay=�8 �� UpdateSourceTrigger$8 PropertyChanged=�m� -   $��CustomGameMenuItem��$��44�����#6498B34 . 5 . 6 �� *
CustomGame+$7 TwoWay=�$8 PropertyChanged=���� 9 � RowDefinitions9 �� �� : � ColumnDefinitions: �� �� �� .+��� $��Custom:��$��	0,0,-10,0q�$��0���� -   $��RowCountTextBox��$��30��$��
20,0,-40,0q�$��Center=�
�������$��0��$��1��.������ ; �� Path$/; )(viewModels:GameViewModel.CustomRowCount)�$7 TwoWay=�$8 	LostFocus=�< �� ValidationRules< <  6PairMatch.ViewModels.GeneratedCardsCountValidationRule  ,  &System.Windows.Controls.ValidationRule=   ValidationStep$= RawProposedValue=�.���� $
��rows��$��
45,0,-45,0q�$��0��$��2���� -   $��ColumnCountTextBox��$��30��$��20,3,-40,-3q�$��Center=�
�������$��1��$��1��.������ $2; ,(viewModels:GameViewModel.CustomColumnCount)�$7 TwoWay=�$8 	LostFocus=�<   $= RawProposedValue=�.���� $
��cols��$��45,3,-45,-3q�$��1��$��2���� m� $	��150��$��20�����#6498B3��� : �� �� �� .+��� $��Timer:��$��	0,0,-10,0q��� -   $��TimerTextBox��$��40��$��
20,0,-40,0q�$��Center=�
�������$��1������ *Timer+$7 TwoWay=�$8 PropertyChanged=��� $	��min��$��
45,0,-45,0q�$��2��m� $��_Help��$��40��$��25��
�������.@�m� -	   $��_About��$��20�����#6498B3� -
   $��GameGrid��$��20,40,20,20q�.+��� -   $��
LevelLabel��$��60��$��30��$
��Left=�$	��Top=�
�������$
��Bold"�$y�Hidden=����� *GameLevelString+$7 OneWay=��� -   $��TimeLeftLabel��$��
Time left:��$��80��$��30��$
��Left=�$	��Top=�$��	210,0,0,0q�$��Right=�
�������$
��Bold"�$y�Hidden=��� -   $��
TimerLabel��$��60��$��30��$��Right=�$	��Top=�$��Right=�
�������$y�Hidden=����� *TimeLeftString+$7 OneWay=��� -   $��CardsListView��$	��360��$	��340��$��Center=�$��Bottom=�$��0,30,0,0q�$��Center=�$
��Auto=�$��Disabled=�  ListViewItemStyle#���  #��[ > �� SelectionMode$> Single=�$y�Hidden=���Z� ��Z� ��Z� ���� .R�A� $��Stretch=�? A� Rows? �� *
RowCount+$7 OneWay=�@ A� Columns@ �� *ColumnCount+$7 OneWay=��� -   $��GameOverLabel��$	��220��$��50��$��Center=�$	��Top=�$��	0,140,0,0q�$��Center=����#90333C$��30(�$
��Bold"�$y�Hidden=��� -   $��NextGameButton��$��85��$��30��$��Center=�$	��Top=�$��	0,220,0,0q�  RoundedButtonStyle#��[ $��ApplicationCommands.New��$y�Hidden=�� -   $��StatisticsGrid��$��20,40,20,20q�$y�Hidden=�.+��� $��Player��$��80��$��30��$
��Left=�$	��Top=�
�������$
��Bold"��� $��	Games won��$��90��$��30��$
��Left=�$	��Top=�$��	100,0,0,0q�$��Center=�
�������$
��Bold"��� $��Games played��$��90��$��30��$
��Left=�$	��Top=�$��	240,0,0,0q�$��Center=�
�������$
��Bold"��� $��Standard��$��60��$��30��$
��Left=�$	��Top=�$��	80,20,0,0q�$��Center=�
�������$
��Bold"��� $��1��$
��Left=�$��Stretch=�$��
147,30,0,0q�
��������� $��Custom��$��60��$��30��$
��Left=�$	��Top=�$��
150,20,0,0q�$��Center=�
�������$
��Bold"��� $��Standard��$��60��$��30��$
��Left=�$	��Top=�$��
220,20,0,0q�$��Center=�
�������$
��Bold"��� $��1��$
��Left=�$��Stretch=�$��
287,30,0,0q�
��������� $��Custom��$��60��$��30��$
��Left=�$	��Top=�$��
290,20,0,0q�$��Center=�
�������$
��Bold"��� $��
0,50,-20,0q�$
��Auto=�.���� -   $��StatisticsItemsControl������ $ viewModels:UserViewModel��.R�� : �� $��80 ��� $��60 ��� $��80 ��� $��60 ��� $��80 �.+��� $��0��
����������� *
Username+�� $��1��$��Center=�
����������� *StandardWonGamesCount+�� $��2��$��Center=�
����������� *CustomWonGamesCount+�� $��3��$��Center=�
����������� *StandardPlayedGamesCount+�� $��4��$��Center=�
����������� *CustomPlayedGamesCount+