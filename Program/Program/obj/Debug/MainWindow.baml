   M S B A M L   `   `   `  ����X  TКурсовой проект, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Курсовой_проектКурсовой_проект  5   	   .    (Курсовой_проект.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:Курсовой_проект     5   	     � Title$  Авторизация��5   	   $	��450��6   $	��800��6*    � Icon$ icon.png��66   .��5	      �    forGrid#��[  6   .+�5
   
   �� $��Авторизация��6   $��Center=�6&   $��0,55,0,0q�6C   $	��Top=�6U   $��24(�6m   �� 5   
   $��
Логин��6   $��Center=�6    $��	0,102,0,0q�6=   $	��Top=�6P   $��20(�6h   
���   �6v   �� 5   
   -   5         ��Name$ Login��5      $
��Left=�6!   $��33��6<   $��297,144,0,0q�6H    �� TextWrapping$
 Wrap=�6]   $	��Top=�6q   $	��188��6�   $��24(�6�   
���   �
���   �6�   �� 5   
   $��Пароль��6   $��Center=�6!   $��	0,190,0,0q�6>   $	��Top=�6Q   $��20(�6i   
���   �6w   G� 5   
   -   5         G�Name$ Password��5      $��Center=�6(   $��	0,235,0,0q�6E   $	��Top=�6X   $	��200��6p   $��33��6|   $��24(�6�   ���	#FF0303036�   �� 5   
   -   5         ��Name$ btnEnter��5      $��Вход��6#   $��Center=�62   $��	0,294,0,0q�6O   $	��Top=�6b   $	��200��6z   $��40��6�   $��20(�6�    � Triggers 5      :� 5       :� RoutedEvent$ Loaded��6   [�5      �� 5      .��5      �� .��5   "   W�  �� TargetProperty$ Width�62   	 �� 
TargetName$	 btnEnter��6T   
 W� From$
 0X�5      	 W� To$	 200X�6(    g� AutoReverse .  g� RepeatBehavior$ 0:0:4.5��6E    g� Duration$ 0:0:1.5D�6^   W� 5   "   $ Height�62   $	 btnEnter��6U   $
 0X�5      $ 30X�6(    . $ 0:0:4.5��6C   $ 0:0:1.5D�6\   5      5      5      5      5       5!      