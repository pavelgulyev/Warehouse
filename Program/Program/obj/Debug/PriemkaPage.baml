   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      X TКурсовой проект, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Курсовой_проектКурсовой_проект 5      _4clr-namespace:Курсовой_проект.Commands&Курсовой_проект.Commands 5	      Y1clr-namespace:Курсовой_проект.Model#Курсовой_проект.Model 5      /   )Курсовой_проект.PriemkaPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      6sys&clr-namespace:System;assembly=mscorlib     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:Курсовой_проект     5      Hcommand4clr-namespace:Курсовой_проект.Commands     5	      ?c1clr-namespace:Курсовой_проект.Model     5      -   5          N� Title$!  Приёмка товара��5       � 	Resources 5      : 4Курсовой_проект.Model.ListCounterparty   	listCount5 /Курсовой_проект.Model.ListSkladov  	listSklad: 4Курсовой_проект.Model.ListTovarPriemka  	listTovar  DateTemplate �� StringFormat  EditingDateTemplate(  "System.Windows.Controls.DatePicker
 �� Now   DisplayDateEnd   SelectedDate �� Mode �� UpdateSourceTrigger��%w  &	        &	      &	 &     &	 9     &	 �       5   
   6     5   
   6     5   
   6   �� 5   
   .R�5      �� $��Center=�5   	   $��Center=�6$   ��5      �� *
Дата+$ {0:dd.}{0:MM.}{0:yyyy}��5   $   5      �� 5   
   .R�5        # Z 6i    6   �� *
Дата+$ TwoWay=�$ PropertyChanged=�6i   5      5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5    
   -   5        8 2Курсовой_проект.Commands.DataCommand	   Delete
   Command#
 Z	 5       5!        5"   
   -   5        $

 Save��5"      5#        5$   
   -   5        $	
 New��5$      5%        5&   
   -   5        $

 Undo��5&      5'        5(   
   -   5           Edit#
 Z 5(      5*      .��5-      �   forGrid#��[ 6   .+�5.   
   c� $	��Top=�6   $��35��6*   .@�5/      �� -   5        $
��Undo��5/       � ToolTip$3 -Отменить редактирование��6!   $
��Undo��6D   .��50      �� $��/Image/Undo.png��6   51      �� 52      -   5        $	��Add��52      $ Добавить��6    $	��New��65   .��53      �� $��/Image/Add.png��6   54      �� 55      -	   5        $
��Edit��55      $  Редактировать��6!   #��Z 69   .��56      �� $��/Image/Edit.png��6   57      �� 58      -
   5        $
��Save��58      $ Сохранить��6!   $
��Save��65   .��59      �� $��/Image/Save.png��6   5:      �� 5;      -   5        $��Delete��5;      $ Удалить��6#   #��Z	 65   .��5<      �� $��/Image/delete.png��6   5=      5?      &   System.Windows.Controls.DataGrid  5@   
   -   5          Name$ DataGridPriemka��5B   /      CanUserDeleteRows .     
IsReadOnly .    AutoGenerateColumns .  $
��Left=�6H   $	��Top=�6c   $��	10,35,0,0q�6{   $��2��6�   $	��650��6�   $	��690��6�      Columns 5C      0  *System.Windows.Controls.DataGridTextColumn  5D      ,	  &System.Windows.Controls.DataGridColumn 	  Header$ Код��6%    	  Width5
  /System.Windows.Controls.DataGridLengthConverter$ 50
 6{   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *Id+$ TwoWay=�$ PropertyChanged=�6{   4  .System.Windows.Controls.DataGridTemplateColumn  5E      $ Дата��6)      CellTemplate# [ 68      CellEditingTemplate# [ 5F   "   $	 100
 5G   )   4  .System.Windows.Controls.DataGridComboBoxColumn  5H      -   5        DataGridContr��$ Контрагент��5H   A      DisplayMemberPath$ Наименование��5L   )   $	 150
 5M   )      SelectedValuePath$ Id��5N   )      SelectedValueBinding 5I   )   ��  �� Path$ Контрагент�$ TwoWay=�$ PropertyChanged=�   ItemsSource 5K   )   ��  �� Source# [  5N   )     5P      -   5        DataGridSklad��$ 
Склад��5P   @   $ 80
 5S   \   $ Наименование��5T   )   $ Id��5U   )    5Q   )   �� # [  5R   )   �� $ 
Склад�$ TwoWay=�$ PropertyChanged=�5U   )     5V      -   5        DataGridTovar��$ 
Товар��5V   @   $	 110
 5Y   \   $ Наименование��5Z   )   $ Id��5[   )    5W   )   �� # [  5X   )   �� $ 
Товар�$ TwoWay=�$ PropertyChanged=�5[   )     5]      $  Количество, шт��6%   $	 100
 5^   r    6!   �� *Количество+$ TwoWay=�$ PropertyChanged=�6r     5_      $ Сумма, руб.��6%   $	 100
 5`   m    6!   �� *
Сумма+$ TwoWay=�$ PropertyChanged=�6m   5b      � 5c   
   $��
12,39,1,10q�6   $	��371��6#   $	��561��6/   $��Right=�6<   .+�5d      �� $,��&Поиск по Контрагенту��6   $��Center=�63   $��0,10,0,0q�6P   $	��Top=�6b   $��14(�6�   ��6z   Z� 6�   �� 5e      -   5         ��Name$ kontrCombobox��5e      $
��Left=�6.    �� SelectedValuePath$ Id��5f       �� DisplayMemberPath$ Наименование��5g      $	��Top=�5i      $��14(�5j      
�������$	��300��69   $��	8,100,0,0q�6E   $��Arial)�6X   ��5h      �� # [  5j   X   �� 5k      $-��'Ввыберите Котрагента��6   $
��Left=�63   $��7,70,0,0q�6N   $	��Top=�6`   $��14(�6�   ��6x   Z� 6�   �� 5l      -   5          ��Name$  btnFindContr��5l      $,��&Поиск по Контрагенту��6+   $
��Left=�6J   $��	7,147,0,0q�6e   $	��Top=�6x   $��14(�6�   $��Arial)�6�   $��30��6�   ! � Triggers! 5m      :� 5n      " :� RoutedEvent$" Loaded��6#   [�5o      �� 5p      .��5q   "   �� .��5r   &   W� # �� TargetProperty$# Width�66   $ W� From$$ 0X�5s      	% W� To$	% 200X�6(   & g� Duration$& 0:0:2D�61   W� 5t   &   $# Height�66   $$ 0X�5u      $% 30X�6(   $& 0:0:2D�60   5v   #   5w      5y      5{      �� 5|      $��Поиск по Дате��6   $��Center=�6,   $��	7,185,0,0q�6I   $	��Top=�6\   $��14(�6�   ��6t   Z� 6�     5}      -   5        '  Name$' FindDate��5}   _   (   DisplayDate$( 
2021-12-30��6   # Z 62   $
��Left=�6q   $��	7,262,0,0q�6�   $	��Top=�6�   $��28��6�   $	��200��6�   $��16(�6�   $��Arial)�6�   )   IsTodayHighlighted) . 6�   �� 5~      $��Выберите дату��6   $
��Left=�6,   $��	7,214,0,0q�6G   $	��Top=�6Z   $��14(�6�   ��6r   Z� 6�   �� 5      -   5        $  btnFindDate��5      $��Поиск по Дате��6*   $
��Left=�6B   $��	7,313,0,0q�6]   $	��Top=�6p   $��14(�6�   $��Arial)�6�   $��30��6�   ! 5�      :� 5�      $" Loaded��6#   [�5�      �� 5�      .��5�   "   �� .��5�   &   W� $# Width�66   $$ 0X�5�      $	% 200X�6(   $& 0:0:2D�61   W� 5�   &   $# Height�66   $$ 0X�5�      $% 30X�6(   $& 0:0:2D�60   5�   #   5�      5�      5�      5�      5�      5�      