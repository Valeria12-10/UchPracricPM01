   M S B A M L   `   `   `  ����=  9WM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WMWM  5   	       WM.Storekeeper   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   "localclr-namespace:WM     5   	   8lex(http://wpflocalizeextension.codeplex.com     5   	      WindowTitle  � Title#  �   5	   	   $	��460��6/   $	��600��6<   ���#F0F0F0.��5
      � .+�5   
   �� .@�5      ��   IncomingInvoiceTab#���  6   .��5      � ���#F0F0F0$��10q�6,    � RowDefinitions 5      �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $��22.96 �6(   �� 5      �� 5      $	��12* �6(    � ColumnDefinitions 5      �� 5      $
��Auto �6+   �� 5      $��* �6+   .+�5      ��   ProductLabel#���  6    $
��Bold"�6F   $��0,5,0,5q�6X   $��0��6i   $��0��6v   �� 5      -   5         ��Name$ cbProductIncoming��5       �� DisplayMemberPath$ Название��6:   $��5,5,5,5q�6W   $��0��6h   $��1��6u   �� 5         QuantityLabel#���  6    $
��Bold"�6G   $��0,5,0,5q�6Y   $��1��6j   $��0��6w   �� 5!      -   5         ��Name$ txtQuantityIncoming��5!      $��5,5,5,5q�6;   $��1��6L   $��1��6Y   �� 5#        DateIncomingLabel#���  6    $
��Bold"�6K   $��0,5,0,5q�6]   $��2��6n   $��0��6{   (  "System.Windows.Controls.DatePicker  5$      -   5          Name$ dpDateIncoming��5$   !   $��5,5,5,5q�69   $��2��6J   $��1��6W   �� 5&        SupplierLabel#���  6    $
��Bold"�6G   $��0,5,0,5q�6Y   $��3��6j   $��0��6w   �� 5'      -   5        $ 
cbSupplier��5'      $ Название��63   $��5,5,5,5q�6P   $��3��6a   $��1��6n   �� 5)      -   5          CreateIncomingInvoiceButton#���  5)        ModernButtonTheme#��[ 6U   $��	253,5,0,2q�6�   $��4��6�   $��1��6�   $
��Left=�6�   $
��10,5q�6�   ���#3EB489$
��Bold"�6  $	��230��6%  $��2��61  z�5*      V� 5+      .~�5,   "   �� �� 5-   "   �� 5.   "   T� 5/   "   50      52      53      54      �� 57        OutgoingInvoiceTab#���  6   .��58      � ���#F0F0F0$��10q�6,    59      �� 5:      $
��Auto �6(   �� 5;      $
��Auto �6(   �� 5<      $
��Auto �6(   �� 5=      $
��Auto �6(   �� 5>      $
��Auto �6(   �� 5?      $	��22* �6(   �� 5@      $
��113* �6(    5B      �� 5C      $
��Auto �6+   �� 5D      $��* �6+   .+�5G      �� #���  6    $
��Bold"�6F   $��	0,5,487,5q�6X   $��0��6k   $��0��6x   $��2��6�   �� 5H      -   5        $ cbProductOutgoing��5H      $ Название��6:   $��92,5,5,5q�6W   $��0��6i   $��1��6v   �� 5J      #���  6    $
��Bold"�6G   $��	0,5,487,5q�6Y   $��1��6l   $��0��6y   $��2��6�   �� 5K      -   5        $ txtQuantityOutgoing��5K      $��92,5,5,5q�6;   $��1��6M   $��1��6Z   �� 5M       	 DateOutgoingLabel#��� 	 6    $
��Bold"�6K   $��	0,5,487,5q�6]   $��2��6p   $��0��6}   $��2��6�     5N      -   5        $ dpDateOutgoing��5N   !   $��92,5,5,5q�69   $��2��6K   $��1��6X   �� 5P       
 ClientLabel#��� 
 6    $
��Bold"�6E   $��	0,5,487,5q�6W   $��3��6j   $��0��6w   $��2��6�   �� 5Q      -	   5        $ cbClient��5Q      $ Название��61   $��92,5,5,5q�6N   $��3��6`   $��1��6m   �� 5S      -
   5          CreateOutgoingInvoiceButton#���  5S      #��[ 6U   $��0,5,5,0q�6�   $��4��6�   $��1��6�   $��Right=�6�   $
��10,5q�6�   ���#3EB489$
��Bold"�6  $	��204��6$  $��2��60  5T      5U      �� 5X        
BarcodeTab#���  6   .��5Y      � ���#F0F0F0$��10q�6,    5Z      �� 5[      $
��Auto �6(   �� 5\      $
��Auto �6(   $��49��66   �� 5]      $
��Auto �6(   $��118.96��66   �� 5^      $
��Auto �6(    5`      �� 5a      $
��Auto �6+   �� 5b      $��* �6+   .+�5e      �� #���  6    $
��Bold"�6F   $��	0,5,526,5q�6X   $��0��6k   $��0��6x   $��2��6�   �� 5f      -   5        $ cbProductBarcode��5f      $ Название��69   $��64,5,5,5q�6V   $��0��6h   $��1��6u   �� 5h      -   5          GenerateBarcodeButton#���  5h      #��[ 6O   $��0,5,0,5q�6�   $��1��6�   $��1��6�   $��Center=�6�   ���#3EB489$
��Bold"�6�   $	��162��6
  �� 5i      -   5         ��Name$ 
imgBarcode��5i      $��	153,5,0,5q�60   $��2��6C   $��1��6P   $
��Left=�6`   $	��200��6{   �� 5j      -   5          PrintBarcodeButton#���  5j      #��[ 6L   $��
0,29,0,-69q�6�   $��3��6�   $��1��6�   $��Center=�6�   ���#3EB489$
��Bold"�6�   $	��162��6  5k      5l      �� 5o        InventoryReportTab#���  6   .��5p      � ���#F0F0F0$��10q�6,    5q      �� 5r      $��* �6(   �� 5s      $
��Auto �6(   .+�5v      &   System.Windows.Controls.DataGrid  -   5          Name$ dgInventoryReport��5v      	   AutoGenerateColumns	 . $��5,5,5,48q�6U   $��0��6g   �� 5w      -   5          ExportToExcelButton#���  5w      #��[ 6M   $��
0,353,5,10q�6�   $��Right=�6�   $
��10,5q�6�   ���#3EB489$
��Bold"�6�   $	��182��6  5x      5y      �� 5|        UserProfileTab#���  6   .��5}      � ���#F0F0F0$��10q�6,    5~      �� 5      $
��Auto �6(   �� 5�      $
��Auto �6(   �� 5�      $
��Auto �6(   �� 5�      $
��Auto �6(   �� 5�      $
��Auto �6(   �� 5�      $��27.96 �6(    5�      �� 5�      $
��Auto �6+   �� 5�      $��* �6+   .+�5�      �� -   5        
 ��Name$
 UserInfoLabel��5�       $��14(�67   $
��Bold"�6E   $��5,5,5,5q�6W   $��0��6h   $��2��6u   �� 5�        UserNameLabel#���  6    $
��Bold"�6G   $��5,5,5,5q�6Y   $��1��6j   $��0��6w   �� 5�      -   5        $ UserNameTextBox��5�      $��5,5,5,5q�68   $��1��6I   $��1��6V   �� 5�        
EmailLabel#���  6    $
��Bold"�6D   $��5,5,5,5q�6V   $��2��6g   $��0��6t   �� 5�      -   5        $ EmailTextBox��5�      $��5,5,5,5q�64   $��2��6E   $��1��6R   �� 5�        NewPasswordLabel#���  6    $
��Bold"�6J   $��5,5,5,4q�6\   $��3��6m   $��0��6z   G� 5�      -   5         G�Name$ PasswordBox��5�   "   $��5,5,5,4q�67   $��3��6H   $��1��6U   �� 5�        
PhotoLabel#���  6    $
��Bold"�6D   $��5,6,5,4q�6V   $��4��6g   $��0��6t   �� 5�      -   5        $ 	UserPhoto��5�      $	��100��6/   $	��100��6;   $��122,6,257,4q�6H   $��4��6]   $��1��6j   �� 5�      -   5          UploadPhotoButton#���  5�      #��[ 6K   $��
5,10,0,-23q�6�   $��5��6�   $��1��6�   $
��Left=�6�   ���#3EB489$
��Bold"�6�   $	��156��6  z�5�      V� 5�      .~�5�   "   �� �� 5�   "   �� 5�   "   T� 5�   "   5�      5�      �� 5�      -   5          
SaveButton#���  5�      #��[ 6D   $��
5,74,0,-84q�6�   $��5��6�   $��1��6�   $
��Left=�6�   ���#3EB489$
��Bold"�6�   $	��156��6�   �� 5�      -   5          LogoutButton#���  5�      #��[ 6F   $��349,32,0,-42q�6�   $��5��6�   $��1��6�   $
��Left=�6�   ���#FF6347$
��Bold"�6�   $	��125��6�   z�5�      V� 5�      .~�5�   "   �� �� 5�   "   �� 5�   "   T� 5�   "   5�      5�      5�      5�      5�      5�      5�      