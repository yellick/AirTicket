   M S B A M L   `   `   `  ����D  @AirTicket, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:AirTicket	AirTicket  5          AirTicket.App   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      )localclr-namespace:AirTicket     5        �� 	Resources  5         FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  TextBox.Static.Border  TextBox.MouseOver.Border1  TextBox.Focus.Border1 	 TextBoxTemplate �� 
TargetType-  'System.Windows.Input.KeyboardNavigation �� 
TargetType ��Name	 �� CornerRadius
 ��Name �� Triggers P� Property P� Value �� 
TargetName �� Triggers ]� 
Conditions �� Property �� Value 
 TextBox.MouseOver.Border  TextBox.Focus.Border  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border  Button.Disabled.Foreground  ButtonTemplate ��Name  IconButtonTemplate  menuButtonTemplate  ListBox.Static.Background  ListBox.Static.Border  ListBox.Disabled.Background  ListBox.Disabled.Border  ListViewTemplate �� Padding��%�  &	        &	 �     &	 �     &	 �     &	     &	 6    &	 Y    &	 |    &	 �    &		 �    7  7  7  &	
 �    &	 �    &	     &	 1    &	 T    &	 w    &	 �    7   7  7  7  7  7  &	 C    7   7  7  &	 �    7   7  7  &	 �    &	     &	 A    &	 d    &	 �    7  7  7  7  �� 5   
   .�5	      ��  � �� 5
      �� 5      .R�5      �� $��2q�6$   $	 1 2R�6/   #��� ��6E    . $��1��6�   5      5      5      �� 5   
   $ 	#FFDDDDDD��6;   �� 5   
   $ 	#FF707070��67   �� 5   
   $ 	#FFBEE6FD��6>   �� 5   
   $ 	#FF3C7FB1��6:   �� 5   
   $ 	#FFC4E5F6��6<   �� 5   
   $ 	#FFABAdB3��68   �� 5   
   $ 	#FF7EB4EA��6<   �� 5   
   $ 	#FF569DE5��68   �� 5   
   " ��6(   .�5      ��  � ��# � ��6+   �� 5       � ��8   6,   �� 5       � ��# � ��6+   �� 5       � ��$ 1q�60   �� 5       �@ TabNavigation$
 None=�6A   �� 5       � ��$
 Left=�6;   �� 5        �@�FocusVisualStyle 61   Z� �� 5!       �@J�	AllowDrop . 6*   �� 5"       �@��PanningMode$ VerticalFirst=�69   �� 5#       �@��IsFlicksEnabled .  67   �� 5$       � �� 5%      �� 5&      " ��6&   .R�5'      �� $ border��6!   $	 15��61   #��z��6C   #��z��6m   #��z��6�    . ._�5(      �� $
 PART_ContentHost��6+   |�.  $��Hidden=�6W   $��Hidden=�6~   5)       5*      P� 5+       � {� .  . �5,   "   �� $ border��6<    �@J�Opacity$
 0.56Q�6P   5-      P� 5.       �@J�IsMouseOver . . �5/   "   �� $ border��6@   8   � ��6T   50      P� 51       �@J�IsKeyboardFocused . . �52   "   �� $ border��6@   8   � ��6T   53      55      57       58      ]� 59       5:      �� 5;      + �@��#IsInactiveSelectionHighlightEnabled . 6S   �� 5<       �@��IsSelectionActive .  6A   ./�5>      ��  �@��SelectionBrush# � /�67   5?      5A      �� 5B   
   $ 	#FF7EB4EA��6;   �� 5C   
   $ 	#FF569DE5��67   �� 5D   
   $ 	#FF2C628B��68   �� 5E   
   $ 	#FFF4F4F4��6=   �� 5F   
   $ 	#FFADB2B5��69   �� 5G   
   $ 	#FF838383��6=   �� 5H   
   " ��6'   .�5I      ��  �@�FocusVisualStyle8   61   �� 5J       � ��8  6+   �� 5K       � ��8  6,   �� 5L       � ��# � ��6+   �� 5M       � ��$ 1q�60   �� 5N       � ��$ Center=�6;   �� 5O       � ��$ Center=�69   �� 5P       � ��$ 1q�6(   �� 5Q       � �� 5R      �� 5S      " ��6&   .R�5T      �� $ border��6!   $	 15��61   #��z��6C   #��z��6m   #��z��6�    . ._�5U      �� $ contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. # z 6�   #��z��6  5V       5W      P� 5X       �@��IsDefaulted . . �5Y   "   �� $ border��6@   # � ��6T    � ��5Z      P� 5[       � {� .  . �5\   "   �� $ border��6?   8   � ��6S   �� 5]   "   $ border��6@   8   � ��6T   �� 5^   "   $ contentPresenter��6K   8   � ��6i   5_      5a      5c      5d      �� 5e   
   " ��6+   .�5f      ��  �@�FocusVisualStyle8   61   �� 5g       � ��8  6+   �� 5h       � ��8  6,   �� 5i       � ��# � ��6+   �� 5j       � ��$ 1q�60   �� 5k       � ��$ Center=�6;   �� 5l       � ��$ Center=�69   �� 5m       � ��$ 1q�6(   �� 5n       � �� 5o      �� 5p      " ��6&   .R�5q      �� $ border��6!   #��z��61   #��z��6]   #��z��6�    . ._�5r      �� $ contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. # z 6�   #��z��6  5s      5t      5v      5w      �� 5x   
   " ��6+   .�5y      ��  �@�FocusVisualStyle8   61   �� 5z       � ��8  6+   �� 5{       � ��8  6,   �� 5|       � ��# � ��6+   �� 5}       � ��$ 1q�60   �� 5~       � ��$ Center=�6;   �� 5       � ��$ Center=�69   �� 5�       � ��$ 1q�6(   �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      �� $ border��6!   #��z��61   #��z��6]   #��z��6�    . ._�5�      �� $ contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. # z 6�   #��z��6  5�      5�      5�      5�      �� 5�   
   $ 	#FFFFFFFF��6<   �� 5�   
   $ 	#FFABADB3��68   �� 5�   
   $ 	#FFFFFFFF��6>   �� 5�   
   $ 	#FFD9D9D9��6:   �� 5�   
   " ��6)   .�5�      ��  � ��8   6+   �� 5�       � ��8  6,   �� 5�       � ��$ 0q�60   �� 5�       � ��# � ��6+   �� 5�       � ��$
 Auto=�6K   �� 5�       � ��$
 Auto=�6I   �� 5�       � �� . 6>   �� 5�       �@��PanningMode$
 Both=�69   �� 5�       �@��IsFlicksEnabled .  67   �� 5�       � ��$ Center=�69   �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      �� $ Bd��6!   #��z��6-   #��z��6Y   #��z��6�   $ 1q�6�    . ._�5�      �� |�.  #��z��6=   .��5�   "   �� # z 61   5�      5�       5�      P� 5�       � {� .  . �5�   "   �� $ Bd��6?   8   � ��6O   �� 5�   "   $ Bd��6@   8   � ��6P   5�      ]� 5�       5�   "   �� 5�   &    �@��
IsGrouping . 6F   �� 5�   &   " �@%�IsVirtualizingWhenGrouping .  6h   ./�5�   "   ��  � �� .  6R   5�      5�      5�      5�      5�      5�      