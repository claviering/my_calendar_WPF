   M S B A M L   `   `   `  ���� C  ?Calendar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CalendarCalendar      Calendar.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     (localclr-namespace:Calendar     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Ced4http://schemas.microsoft.com/expression/2010/drawing     -     � Title$  Calendar��$	��215��$	��450��$��Consolas)�$��12(� � 
ResizeMode$ NoResize=� � ShowInTaskbar .   � WindowStyle$ 
ToolWindow=�.����  �� Orientation$ 
Horizontal=�.+�� -    �Name$ myGrid��$	��250�� � RowDefinitions �� $��25 ��� $��13 ��� �� �� �� �� ��  � ColumnDefinitions �� �� �� �� �� �� �� .+��� -    ��Name$ label00��$��1��$��0��$	��Sun��$
��Bold"�	 �� TextAlignment$	 Center=�$��10(��� -   $ label01��$��1��$��1��$	��Mon��$
��Bold"�$	 Center=�$��10(��� -   $ label02��$��1��$��2��$	��Tue��$
��Bold"�$	 Center=�$��10(��� -   $ label03��$��1��$��3��$	��Wed��$
��Bold"�$	 Center=�$��10(��� -   $ label04��$��1��$��4��$	��Thu��$
��Bold"�$	 Center=�$��10(��� -   $ label05��$��1��$��5��$	��Fri��$
��Bold"�$	 Center=�$��10(��� -	   $ label06��$��1��$��6��$	��Sat��$
��Bold"�$	 Center=�$��10(��� -
   $��	txtCMonth��$��2��$��3��$��0000-00��$	 Center=�$��19(�$
��Bold"��� -   $��txtLeft��$��1��$��<<��$	 Center=�$��18(�
�������
 � Cursor$

 Hand��$
��Bold"��� -   $��txtRight��$��5��$��>>��$	 Center=�$��18(�
�������$

 Hand��$
��Bold"��� -   $��01��$��2��$��0��$
��Bold"�$��Center=�$��Center=��� -   $��02��$��2��$��1��$
��Bold"�$��Center=�$��Center=��� -   $��03��$��2��$��2��$
��Bold"�$��Center=�$��Center=��� -   $��04��$��2��$��3��$
��Bold"�$��Center=�$��Center=��� -   $��05��$��2��$��4��$
��Bold"�$��Center=�$��Center=��� -   $��06��$��2��$��5��$
��Bold"�$��Center=�$��Center=��� -   $��07��$��2��$��6��$
��Bold"�$��Center=�$��Center=��� -   $��08��$��3��$��0��$
��Bold"�$��Center=�$��Center=��� -   $��09��$��3��$��1��$
��Bold"�$��Center=�$��Center=��� -   $��10��$��3��$��2��$
��Bold"�$��Center=�$��Center=��� -   $��11��$��3��$��3��$
��Bold"�$��Center=�$��Center=��� -   $��12��$��3��$��4��$
��Bold"�$��Center=�$��Center=��� -   $��13��$��3��$��5��$
��Bold"�$��Center=�$��Center=��� -   $��14��$��3��$��6��$
��Bold"�$��Center=�$��Center=��� -   $��15��$��4��$��0��$
��Bold"�$��Center=�$��Center=��� -   $��16��$��4��$��1��$
��Bold"�$��Center=�$��Center=��� -   $��17��$��4��$��2��$
��Bold"�$��Center=�$��Center=��� -   $��18��$��4��$��3��$
��Bold"�$��Center=�$��Center=��� -   $��19��$��4��$��4��$
��Bold"�$��Center=�$��Center=��� -    $��20��$��4��$��5��$
��Bold"�$��Center=�$��Center=��� -!   $��21��$��4��$��6��$
��Bold"�$��Center=�$��Center=��� -"   $��22��$��5��$��0��$
��Bold"�$��Center=�$��Center=��� -#   $��23��$��5��$��1��$
��Bold"�$��Center=�$��Center=��� -$   $��24��$��5��$��2��$
��Bold"�$��Center=�$��Center=��� -%   $��25��$��5��$��3��$
��Bold"�$��Center=�$��Center=��� -&   $��26��$��5��$��4��$
��Bold"�$��Center=�$��Center=��� -'   $��27��$��5��$��5��$
��Bold"�$��Center=�$��Center=��� -(   $��28��$��5��$��6��$
��Bold"�$��Center=�$��Center=��� -)   $��29��$��6��$��0��$
��Bold"�$��Center=�$��Center=��� -*   $��30��$��6��$��1��$
��Bold"�$��Center=�$��Center=��� -+   $��31��$��6��$��2��$
��Bold"�$��Center=�$��Center=��� -,   $��32��$��6��$��3��$
��Bold"�$��Center=�$��Center=��� --   $��33��$��6��$��4��$
��Bold"�$��Center=�$��Center=��� -.   $��34��$��6��$��5��$
��Bold"�$��Center=�$��Center=��� -/   $��35��$��6��$��6��$
��Bold"�$��Center=�$��Center=��� -0   $��36��$��7��$��0��$
��Bold"�$��Center=�$��Center=��� -1   $��37��$��7��$��1��$
��Bold"�$��Center=�$��Center=��� -2   $��38��$��7��$��2��$
��Bold"�$��Center=�$��Center=��� -3   $��39��$��7��$��3��$
��Bold"�$��Center=�$��Center=��� -4   $��40��$��7��$��4��$
��Bold"�$��Center=�$��Center=��� -5   $��41��$��7��$��5��$
��Bold"�$��Center=�$��Center=��� -6   $��42��$��7��$��6��$
��Bold"�$��Center=�$��Center=��� $	��200��.+��� -7   $ 	textBlock��$
��Wrap=�$��	TextBlock��$��20��
 �� Top$ 40���� -8    ��Name$ image��$��32�� �� Right$ 10�� �� Bottom$ 5��$��32��$��add_plus.png���� -9   $ image1��$��32��$ 10��$ 5��$��32��$��save_notes.png��$y�Hidden=��� -:    ��Name$ textBox��$��80�� �� AcceptsReturn . " �� VerticalScrollBarVisibility$
 Auto=� �� TextWrapping$
 Wrap=�$�� ��$ 65��$	��187�� �� Left$ 3��$y�Hidden=��� -;   $ image2��$��32��$ 45��$ 5��$��32�� J� RenderTransformOrigin$ 0.469,0.469&�$��
delete.png��$y�Hidden=��� -<   $ textBox1�� �� 
IsReadOnly . $ 3��$
 Wrap=�$��TextBox��$ 65��$��80��$	��187�� �� SelectionBrush
 ������� -=   $ 
textBlock1��$��19��$	 145��$
��Wrap=�$
��Week��$ 10��$��40��$ 0,0.435&�$��Lucida Sans Unicode)�$��14(��� ->   $ 
textBlock2��$��19��$ 95��$
��Wrap=�$��Month��$ 10��$��45��$ 0,0.435&�$��Lucida Sans Unicode)�$��14(��� -?   $ today��$��19��$ 45��$
��Wrap=�$��Today��$ 10��$��45��$ 0,0.435&�$��Lucida Sans Unicode)�$��14(�