   M S B A M L   `   `   `  ����L  HCSC343-calculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:CSC343_calculator.ViewsCSC343_calculator.Views  5   	   %    CSC343_calculator.Views.TopView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:CSC343_calculator.Views     5   	     � Title$  TopView��5   	   $	��400��6   $	��600��6&   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      .+�5   
   �� -   5         ��Name$ ClearButton��5      $��1��6&   $��0��66   $��10q�6C   .��6i   Clear calculations6}   � 5   
   $��0��6    5      �� 5      �� 5      .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6&   .+�5      �� .��6   
Attributes6$   �� 5      -   5         ��Name$ ClosureAttributes��5      $��Center=�65   $��Stretch=�6P   5      �� 5      $��1��6   $ 
Horizontal=�6&   .+�5      �� .��6   FDs6   �� 5      -   5        $ 
ClosureFDs��5       �� AcceptsReturn . $��Center=�6C   $��Stretch=�6^   5      5       �� 5!   
   -   5         ��Name$ closureGroupBox��5!      $��0��6,   $��1��6<   $��Closure��6I   $��10,10,10,10q�6Z   .��5"      �  5#      �� 5$      $
��auto �6$   �� 5%      $
��auto �6$   �� 5&      $
��auto �6$   �� 5'      $
��auto �6$   �� 5(      $
��auto �6$   �� 5)      $
��auto �6$   �� 5*      $
��auto �6$   �� 5+      .+�5/      �� $��0��6   $ 
Horizontal=�6*   .+�50      �� .��6   
Closure of6(   �� 51      -   5        $ ClosureTarget1��51      $	��115��66   $��Center=�6B   $	��0,5q�6]   6l   �� 52      .��6   is:6!   53      �� 54      -   5         ��Name$ ClosureResult1��54      $��1��60   $��Center=�6=   6Z   �� 57      $��2��6   $ 
Horizontal=�6*   .+�58      �� .��6   
Closure of6(   �� 59      -   5        $ ClosureTarget2��59      $	��115��66   $��Center=�6B   $	��0,5q�6]   6l   �� 5:      .��6   is:6!   5;      �� 5<      -   5        $ ClosureResult2��5<      $��3��60   $��Center=�6=   6Z   �� 5?      $��4��6   $ 
Horizontal=�6*   .+�5@      �� .��6   
Closure of6(   �� 5A      -	   5        $ ClosureTarget3��5A      $	��115��66   $��Center=�6B   $	��0,5q�6]   6l   �� 5B      .��6   is:6!   5C      �� 5D      -
   5        $ ClosureResult3��5D      $��5��60   $��Center=�6=   6Z   �� 5G      $��6��6   $ 
Horizontal=�6*   .+�5H      �� .��6   
Closure of6(   �� 5I      -   5        $ ClosureTarget4��5I      $	��115��66   $��Center=�6B   $	��0,5q�6]   6l   �� 5J      .��6   is:6!   5K      �� 5L      -   5        $ ClosureResult4��5L      $��7��60   $��Center=�6=   6Z   5N      5O      �� 5P   
   -   5        $ minimalBasisGroupBox��5P      $��1��61   $��1��6A   $��Minimal Basis Step 3��6N   $��10,10,10,10q�6l   .��5Q      �  5R      �� 5S      $
��auto �6$   �� 5T      $
��auto �6$   �� 5U      $
��auto �6$   .+�5W      �� $��0��6   $ 
Horizontal=�6*   .+�5X      �� .��6   The closure of6-   �� 5Y      -   5        $ MinLHS��5Y      $��Center=�6.   	 �� 
IsReadOnly	 . $��60��6[   6h   5Z      �� 5[      $��1��6   $ 
Horizontal=�6*   .+�5\      �� .��6   
without FD6(   �� 5]      -   5        $ 	WithoutFD��5]      $��Center=�61   $��60��6L   6Y   �� 5^      .��6   is:6!   5_      �� 5`      -   5        $ ClosureWithoutFD��5`      $��2��62   6A   5a      5b      5c      5d      