   M S B A M L   `   `   `  ����=  9WM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WMWM  5   	       WM.OrderWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   "localclr-namespace:WM     5   	   8lex(http://wpflocalizeextension.codeplex.com     5   	      WindowTitle  � Title#  �   5	   	   $	��500��6/   $	��400��6<   ���#E0F7FA � WindowStartupLocation$ CenterScreen=�5
   	    � 
ResizeMode$ NoResize=�5   	   .��5      � $��	0,0,0,-88q�6    � RowDefinitions 5   
   �� 5      $
��429* �6   �� 5      $	��60* �6   �� 5      $	��48* �6   �� 5      $	��35* �6   .+�5   
   �� $��4��6   .@�5      ��   SupplierOrdersTab#���  6   .��5      � ���#E0F7FA.+�5      �� $��20q�6!   $��Center=�6-   .+�5      ��   OrderTypeLabel#���  6    $
��Bold"�6K   $��Italic$�6]   �� 5      -   5         ��Name$ cbOrderType��5   #   $	��300��68   $��10q�6D   ���#3EB489$��2q�6g   .@�5      ��  
 Retail#���  6+   �� 5        	Wholesale#���  6+   5      �� 5        SelectProductLabel#���  6    $
��Bold"�6O   $��Italic$�6a   $��0,10,0,0q�6t   �� 5      -   5        $ cbProductOrder��5   #   $	��300��6;   $��10q�6G   ���#3EB489$��2q�6j   �� 5!        SelectSupplierLabel#���  6    $
��Bold"�6P   $��Italic$�6b   $��0,10,0,0q�6u   �� 5"      -   5        $ cbPostav��5"   #   $	��300��65   $��10q�6A   ���#3EB489$��2q�6d   �� 5$        EnterQuantityLabel#���  6    $
��Bold"�6O   $��Italic$�6a   $��0,10,0,0q�6t   �� 5%      -   5         ��Name$ txtQuantityOrder��5%   "   $	��300��6<   $��10q�6H   ���#3EB489$��2q�6k   �� 5'        OrderDateLabel#���  6    $
��Bold"�6K   $��Italic$�6]   $��0,10,0,0q�6p   (  "System.Windows.Controls.DatePicker  5(      -   5          Name$ dpDateOrder��5(   %   $	��300��6:   $��10q�6F   ���#3EB489$��2q�6i   �� 5*      -   5         	 CreateOrderButton#��� 	 5*   !    
 ModernButtonTheme#��[
 6O   $	��300��6z   $��	0,20,0,10q�6�   $��40��6�   �� 5+      -   5         ��Name$
 Exit��5+   !     
BackButton#���  6/   #��[
 6V   $��40��6�   $	��120��6�   $��Center=�6�   5,      5-      5.      �� 51        CustomerOrdersTab#���  6   .��52      � ���#E0F7FA.+�53      �� $��20q�6!   $��Center=�6-   .+�54      �� #���  6    $
��Bold"�6K   $��Italic$�6]   �� 55      -   5        $ cbOrderType1��55   #   $	��300��69   $��10q�6E   ���#3EB489$��2q�6h   .@�56      �� #���  6+   �� 57      #���  6+   58      �� 5:      #���  6    $
��Bold"�6O   $��Italic$�6a   $��0,10,0,0q�6t   �� 5;      -	   5        $ cbProductOrder1��5;   #   $	��300��6<   $��10q�6H   ���#3EB489$��2q�6k   �� 5=        SelectClientLabel#���  6    $
��Bold"�6N   $��Italic$�6`   $��0,10,0,0q�6s   �� 5>      -
   5        $ cbClient��5>   #   $	��300��65   $��10q�6A   ���#3EB489$��2q�6d   �� 5@      #���  6    $
��Bold"�6O   $��Italic$�6a   $��0,10,0,0q�6t   �� 5A      -   5        $ txtQuantityOrder1��5A   "   $	��300��6=   $��10q�6I   ���#3EB489$��2q�6l   �� 5C      #���  6    $
��Bold"�6K   $��Italic$�6]   $��0,10,0,0q�6p     5D      -   5        $ dpDateOrder1��5D   %   $	��300��6;   $��10q�6G   ���#3EB489$��2q�6j   �� 5F      -   5        $ ClientOrder��5F   !   #��[
 66   #��� 	 6a   $	��300��6�   $��	0,20,0,10q�6�   $��40��6�   �� 5G      -   5        $ Exit1��5G   H   #���  6!   #��[
 6W   $��40��6�   $	��120��6�   $��Center=�6�   5H      5I      5J      5K      5L      5M      