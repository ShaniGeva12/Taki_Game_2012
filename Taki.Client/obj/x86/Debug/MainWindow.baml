   M S B A M L   `   `   `  ����  Taki.Client    Taki.Client.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  
MainWindow��5   	   $	��439��6   $	��904��6)    � WindowStyle$ 
ToolWindow=�6L    � 	Resources 5         TakiTextBlockStory g� RepeatBehavior �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value��%G  &	        �� 5   
   $ Forever��60   .��5      U� $U O(TextElement.Foreground).(GradientBrush.GradientStops)[1].(GradientStop.Offset)�6#   $ 	textBlock��6�   .\�5        $ 0��6   $ 0Q�6'     5	      $ 0:0:0.5��6   $ 0.836Q�6-     5
      $ 0:0:1��6   $ 0Q�6+   5      5      5       � Triggers 5      :� 5      	 :� RoutedEvent$	 FrameworkElement.Loaded��6   .[�5      �� #��[  6   5      .��5      � .+�5   
    � -   5        $��frame1��5   ,   $��Right=�6   $	��Top=�6:   �� 5   
   -   5        
 ��Name$
 	textBlock��5      $��8,8,0,0q�6'   $
��Wrap=�68   $
��Taki��6L   $��48(�6X   $
��Left=�6f   $��97��6�   $
��59.9��6�   $	��Top=�6�   ��6�   Z� ��5      �� 5       �� EndPoint$ 0.5,1&�6     �� 
StartPoint$ 0.5,0&�61   .��5      �  � Color$ Black��6    � Offset$ 1Q�6(   � 5      $ 	#FFEF9C36��6   $ 0.453Q�6,   5      5      �� 5   
   -   5        $��stackPanel1��5   P   $	��314��6   $
��Left=�6"   $��	12,74,0,0q�6=   $	��Top=�6c   $��89��6{   .+�5      �� -   5        $��button1��5   2   $��Button��6   $��23��6&   $��75��6A   �� 5       -   5        $��button2��5    2   $��Button��6   $��23��6&   $��75��6A   �� 5!      -   5        $��button3��5!   2   $��Button��6   $��23��6&   $��75��6A   �� 5"      -   5        $��button4��5"   2   $��Button��6   $��23��6&   $��75��6A   5#      5$      5%      