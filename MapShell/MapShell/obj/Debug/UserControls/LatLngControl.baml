   M S B A M L   `   `   `  ����  MapShell)    #MapShell.UserControls.LatLngControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      � 
�������$��5q�6#     � RowDefinitions  5	   
   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��40��6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 5Q�6      ShadowDepth$ 1Q�6.      	Direction$	 270Q�6>   .+�5   
   �� $��3��6   .+�5      �� $��Latitude��6   $��	10,0,10,0q�6'   �� 5      -   5         ��Name$ Latitude��5      $��	10,0,10,5q�5      5      �� 5   
   $��1��6   $��3��6"   .+�5      �� $��	Longitude��6   $��	10,0,10,0q�6(   �� 5       -   5        $ 	Longitude��5       $��1��5!      $��	10,0,10,0q�5"      $��3��5#      5$      �� 5'   
   -   5        $��4��5'      $��30��6!   $��30��6-   .��5(      �� .+�5)      �� $��x.png��6   5*      5+      5,      5-      