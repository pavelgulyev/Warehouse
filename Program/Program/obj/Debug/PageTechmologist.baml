   M S B A M L   `   `   `  ����X  TКурсовой проект, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Курсовой_проектКурсовой_проект  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      _4clr-namespace:Курсовой_проект.Commands&Курсовой_проект.Commands  5      Y1clr-namespace:Курсовой_проект.Model#Курсовой_проект.Model  5      4    .Курсовой_проект.PageTechmologist   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:Курсовой_проект     5      6sys&clr-namespace:System;assembly=mscorlib     5      Hcommand4clr-namespace:Курсовой_проект.Commands     5      ?c1clr-namespace:Курсовой_проект.Model     5      -   5          N� Title$  PageTechmologist��5
       � 	Resources 5      :  4Курсовой_проект.Model.ListCounterparty   	listCount5  /Курсовой_проект.Model.ListSkladov  	listSklad:  4Курсовой_проект.Model.ListTovarPriemka  	listTovar��%W   &	        &	      &	 &       5   
   6     5   
   6     5   
   6   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        8  2Курсовой_проект.Commands.DataCommand   Delete   Command# Z 5      5        5   
   -   5        $
 Save��5      5        5   
   -   5        $	 New��5      5         5!   
   -   5        $
 Undo��5!      5"        5#   
   -   5           Edit# Z 5#      5%      .��5(      �   forGrid#��[ 6   .+�5*   
   c� $	��Top=�6   $��35��6*   .@�5+      �� -   5        $
��Undo��5+       � ToolTip$3 -Отменить редактирование��6!   $
��Undo��6D   .��5,      �� $��/Image/Undo.png��6   5-      �� 5.      -   5        $	��Add��5.      $ Добавить��6    $	��New��65   .��5/      �� $��/Image/Add.png��6   50      �� 51      -	   5        $
��Edit��51      $  Редактировать��6!   #��Z 69   .��52      �� $��/Image/Edit.png��6   53      �� 54      -
   5        $
��Save��54      $ Сохранить��6!   $
��Save��65   .��55      �� $��/Image/Save.png��6   56      �� 57      -   5        $��Delete��57      $ Удалить��6#   #��Z 65   .��58      �� $��/Image/delete.png��6   59      5:      &   System.Windows.Controls.DataGrid  5;   
   -   5          Name$ DataGridTehcCard��5=   /      CanUserDeleteRows .  	   
IsReadOnly	 . 
   AutoGenerateColumns
 .  $
��Left=�6I   $	��Top=�6d   $��	10,35,0,0q�6|   $��2��6�   $	��650��6�   $	��690��6�      Columns 5>      0  *System.Windows.Controls.DataGridTextColumn  5?      ,  &System.Windows.Controls.DataGridColumn   Header$ Код��6%      Width5	  /System.Windows.Controls.DataGridLengthConverter$ 30	 6{   1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 62   �� *Id+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6{   4  .System.Windows.Controls.DataGridComboBoxColumn  5A      -   5        DataGridContr��$ Материал��5A   A      DisplayMemberPath$ Наименование��5E   )   $	 150	 5F   )      SelectedValuePath$ Id��5G   )      SelectedValueBinding 5B   )   ��  �� Path$ Материал�$ TwoWay=�$ PropertyChanged=�   ItemsSource 5D   )   ��  �� Source# [ 5G   )     5I      -   5        DataGridSklad��$' !Готовая продукция��5I   @   $	 150	 5L   \   $ Наименование��5M   )   $ Id��5N   )    5J   )   �� # [  5K   )   �� $' !Готовая_продукция�$ TwoWay=�$ PropertyChanged=�5N   )     5P      $\ VЗатраты на производство готовой продукции, руб��6%   $	 300	 5Q       6!   �� *.,Затраты_на_производство+$ TwoWay=�$ PropertyChanged=�6   5S      � 5T   
   $��
12,39,1,10q�6   $	��371��6#   $	��561��6/   $��Right=�6<   .+�5U      �� $&�� Поиск по Материал��6   $��Center=�60   $��0,10,0,0q�6M   $	��Top=�6_   $��14(�6�   ��6w   Z� 6�   �� 5V      -   5         ��Name$ MatCombobox��5V      $
��Left=�6,    �� SelectedValuePath$ Id��5W       �� DisplayMemberPath$ Наименование��5X      $	��Top=�5Z      $��14(�5[      
�������$	��300��69   $��	8,100,0,0q�6E   $��Arial)�6X   ��5Y      �� # [ 5[   X   �� 5\      $)��#Ввыберите Материал��6   $
��Left=�61   $��7,70,0,0q�6L   $	��Top=�6^   $��14(�6�   ��6v   Z� 6�   �� 5]      -   5         ��Name$ 
btnFindMat��5]      $(��"Поиск по Материалу��6)   $
��Left=�6F   $��
10,147,0,0q�6a   $	��Top=�6u   $��14(�6�   $	��200��6�   $��Arial)�6�   $��30��6�   5^      �� 5_      $7��1Поиск по Готовому продукту��6   $��Center=�69   $��	7,185,0,0q�6V   $	��Top=�6i   $��14(�6�   ��6�   Z� 6�   �� 5`      -   5        $ ProductCombobox��5`      $
��Left=�60   $ Id��5a      $ Наименование��5b      $	��Top=�5d      $��14(�5e      
�������$	��300��69   $��	7,262,0,0q�6E   $��Arial)�6X   ��5c      �� # [ 5e   X   �� 5f      $8��2Выберите Готовому продукту��6   $
��Left=�69   $��	7,214,0,0q�6T   $	��Top=�6g   $��14(�6�   ��6   Z� 6�   �� 5g      -   5        $ btnFindProduct��5g      $7��1Поиск по Готовому продукту��6-   $
��Left=�6R   $��
10,313,0,0q�6m   $	��Top=�6�   $��14(�6�   $��Arial)�6�   $��30��6�   6�   5i      5j      5k      