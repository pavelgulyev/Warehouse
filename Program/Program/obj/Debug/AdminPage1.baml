   M S B A M L   `   `   `  ����X  TКурсовой проект, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Курсовой_проектКурсовой_проект  5      _4clr-namespace:Курсовой_проект.Commands&Курсовой_проект.Commands  5      Y1clr-namespace:Курсовой_проект.Model#Курсовой_проект.Model  5	      .    (Курсовой_проект.AdminPage1   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:Курсовой_проект     5      Hcommand4clr-namespace:Курсовой_проект.Commands     5      ?c1clr-namespace:Курсовой_проект.Model     5	      -   5          N� Title$  
AdminPage1��5       � 	Resources 5      :  4Курсовой_проект.Model.ListCounterparty   	listCount5  /Курсовой_проект.Model.ListSkladov  	listSklad:  4Курсовой_проект.Model.ListTovarPriemka  	listTovar��%W   &	        &	      &	 &       5   
   6     5   
   6     5   
   6   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        8  2Курсовой_проект.Commands.DataCommand   Delete   Command# Z 5      5        5   
   -   5        $
 Save��5      5        5   
   -   5        $	 New��5      5        5   
   -   5        $
 Undo��5      5        5   
   -   5           Edit# Z 5      5       .��5#      �   forGrid#��[ 6   .+�5$   
   c� $	��Top=�6   $��35��6*   .@�5%      �� -   5        $
��Undo��5%       � ToolTip$3 -Отменить редактирование��6!   $
��Undo��6D   .��5&      �� $��/Image/Undo.png��6   5'      �� 5(      -   5        $	��Add��5(      $ Добавить��6    $	��New��65   .��5)      �� $��/Image/Add.png��6   5*      �� 5+      -	   5        $
��Edit��5+      $  Редактировать��6!   #��Z 69   .��5,      �� $��/Image/Edit.png��6   5-      �� 5.      -
   5        $
��Save��5.      $ Сохранить��6!   $
��Save��65   .��5/      �� $��/Image/Save.png��6   50      �� 51      -   5        $��Delete��51      $ Удалить��6#   #��Z 65   .��52      �� $��/Image/delete.png��6   53      55      &   System.Windows.Controls.DataGrid  56   
   -   5          Name$ DataGridUser��58   /      CanUserDeleteRows .  	   
IsReadOnly	 . 
   AutoGenerateColumns
 .  $
��Left=�6E   $	��Top=�6`   $��	10,35,0,0q�6x   $��2��6�   $	��650��6�   $	��690��6�      Columns 59      0  *System.Windows.Controls.DataGridTextColumn  5:      ,  &System.Windows.Controls.DataGridColumn   Header$ Код��6%      Width5	  /System.Windows.Controls.DataGridLengthConverter$ 50	 6{   1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 62   �� *Id+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6{     5;      $ Наименование��6%   $	 300	 5<   t    6!   �� *Наименование+$ TwoWay=�$ PropertyChanged=�6t     5=      $ 
Адрес��6%   $	 300	 5>   m    6!   �� *
Адрес+$ TwoWay=�$ PropertyChanged=�6m   5A      � 5B   
   $��
12,39,1,10q�6   $	��371��6#   $	��561��6/   $��Right=�6<   .+�5C      �� $"��Поиск по Адресу��6   $��Center=�6.   $��0,10,0,0q�6K   $	��Top=�6]   $��14(�6�   ��6u   Z� 6�   �� 5D      -   5         ��Name$ Adress��5D      $��14(�6&   $	��300��64   $��20��6@   $	��Top=�6L   $
��Left=�6d   $��
10,120,0,0q�6   .��6�   5E      �� 5F      $!��Введите Адресу��6   $
��Left=�6-   $��7,70,0,0q�6H   $	��Top=�6Z   $��14(�6�   ��6r   Z� 6�   �� 5G      -   5         ��Name$ btnFindAdress��5G      $"��Поиск по Адресу��6,   $
��Left=�6F   $��	7,147,0,0q�6a   $	��Top=�6t   $��Arial)�6�   $��30��6�    � Triggers 5H      :� 5I       :� RoutedEvent$ Loaded��6#   [�5J      �� 5K      .��5L   "   �� .��5M   &   W�  �� TargetProperty$ Width�66    W� From$ 0X�5N      	 W� To$	 200X�6(    g� Duration$ 0:0:2D�61   W� 5O   &   $ Height�66   $ 0X�5P      $ 30X�6(   $ 0:0:2D�60   5Q   #   5R      5T      5V      5W      5X      5Y      