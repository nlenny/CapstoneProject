   M S B A M L   `   `   `  ����  MapShell    MapShell.SettingsWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  SettingsWindow��5   	   $	��300��6    $	��300��6-   .��5      � .+�5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5	      $
��Auto �6    �� 5
      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $��* �6     � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   .+�5      �� $��Avoid the Following:��6   $
��Bold"�63   �� 5      $��1��6    �� Orientation$ Vertical=�6&   .+�5      ��  d� 	IsChecked 6   �� *	tollroads+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.��6m   
Toll Roads6y   �� 5       6   �� *	unPaved+$ TwoWay=�$ PropertyChanged=�.��6k   Unpaved Roads6z   �� 5       6   �� *
highways+$ TwoWay=�$ PropertyChanged=�.��6l   
Highways6v   5      �� 5      $
��Bold"�6   $��1��6&   $��Trip Preference:��5      �� 5      $ Vertical=�6   $��1��60   $��1��6=   .+�5       	�  	� 	GroupName$
 Pref��6   $��Shortest Time��6/    6G   �� *shortestTime+$ TwoWay=�$ PropertyChanged=�	� 5!      $
 Pref��6   $��Shortest Distance��6/    6K   �� *shortestDistance+$ TwoWay=�$ PropertyChanged=�5"      �� 5&      $��Display the Following:��6   $��2��65   $
��Bold"�5'      �� 5(      $��3��6   $ Vertical=�6&   .+�5)      �� -   5        $��roundTripDirections��5)      .��66   Round Trip Directions5+      5,      �� 5/      $��Type of Map: ��6   $��2��6,   $��1��69   $
��Bold"�6I   �� 50      $ Vertical=�6   $��3��60   $��1��6=   .+�51      	� $ mapType��6   $��Map Only��62    6E   �� *	mapOnly+$ TwoWay=�$ PropertyChanged=�	� 52      $ mapType��6   $��	Satellite��62    6F   �� *	satellite+$ TwoWay=�$ PropertyChanged=�	� 53      $ mapType��6   $��Hybrid��62    6C   �� *hybrid+$ TwoWay=�$ PropertyChanged=�54      �� 56      -   5        $��4��56      $��1��6"   $��Update��57      $��Right=�6.   $��Bottom=�58      59      5;      5<      