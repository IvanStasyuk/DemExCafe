   M S B A M L   `   `   `  ����G  CAppDemExCafe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:AppDemExCafeAppDemExCafe  5   	       AppDemExCafe.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:AppDemExCafe     5   	     � Icon$  Resources/image_icon.png��5   +    � Title$B <Заведение общественного питания��5   	   $	��800��61   $
��1200��6A   $	��800��6Q   $
��1200��6a   .��5	      � -   5         �Name$ FonBackground��5	       � ColumnDefinitions 5
   
   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      $	��130 �6   6+   �� 5      6   �� 5      6   �� 5      6   �� 5      $��50 �6   6*   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��Center=�6K   $��1��6f   $��1��6z   $��30q�6�   .+�5      �� $5��/pack://application:,,,/Resources/image_icon.png��6   6O   5       � 5   
   -   5          �Name$ 	CafeFrame��5        � NavigationUIVisibility$ Hidden=�6#   $��0��6C   $��1��6S   $��5��6`   $��3��6t   6�   �� 5   
   -   5         ��Name$ 	TextStart��5      $��1��6b   $��3��6r   ��6'   �� 	 �� ElementName$	 	CafeFrame��
 �� Path$
 Content.Title�6�   �� 5   
   -   5         ��Name$ CanToGo��5      $��Вернуться��6"   $��2��66   $��4��6F   $y�Visible=�6S      	ButtonAdd#��[  6h   6�   5      5      