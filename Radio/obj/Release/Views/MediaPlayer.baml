   M S B A M L   `   `   `  ���� @  <Radio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Radio.ViewsRadio.Views      Radio.Views.MediaPlayer   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     +localclr-namespace:Radio.Views     -     � Title$  MediaPlayer��$	��450��$	��800��.���  � RowDefinitions �� $
��0.5* ��� $��* � � ColumnDefinitions �� $
��0.5* ��� $��* ��� $
��0.5* �.+��� $��1��$��3��
������� �� Orientation$ Vertical=�.+��� $ 
Horizontal=�.+��� -   $	��120��$��20��$��10,1, 10, 0q�$��Выбрать файл���� $��2��.���� -    ��Name$ 	m_listBox��
�������
������� �� View �� P��� $��Трек�� �� Width$	 100��-   	TrackName���� $��
Время��$ 80��-   	TrackTime���� $��1��$ 
Horizontal=�
��������� 
�������.+��� -   $��
PosOfMusic���� -   $��TimeOfMusic���� -    ��Name$ m_Slider��$��10, 10, 10,0q� � ToolTip$ Слайдер��	 J� IsManipulationEnabled	 . {�. 
 �� IsMoveToPointEnabled
 .  J� 	AllowDrop . �� -	   $ m_Volume��$��10, 5, 10, 0q�$ Громкость��$	��150���� $��60��$ 
Horizontal=�.+��� $��20��$��20��$��
15,20,0,20q�
�������$) #Предыдущая дорожка���� -
   $��20��$��20��
�������$" Воспроизводить��$��P���� $��20��$��20��
�������$  Приостановить��$��S���� -   $��20��$��20��
�������$ Остановить���� $��20��$��20��
�������$' !Следующая дорожка���� $��20��$��20��$��20q�
�������$ Открыть файл��