   M S B A M L   `   `   `  ����D  @AirTicket, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:AirTicket	AirTicket  5      &     AirTicket.pageUserBookingTickets   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:AirTicket     5        N� Title$  pageUserBookingTickets��5	      .��5      � .+�5   
   �� -   5         ��Name$ ticketsList��5      $	��533��6)   $	��Top=�66      ListViewTemplate#���   6{   $��Disabled=�6�   $��225,70,225,0q�6�   ��6N   Z� ��6d   Z� ��6�   Z� ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property �@J�IsHitTestVisible �� Value .  69   5      ��5      �� 5      .R�5      � $	��995��6    � Cursor$
 Hand��6'   ���	#FF4D4D4D$��0,0,0,10q�6L    � RowDefinitions 5      �� 5      $	��110 �6,   6;   �� 5      $
��Auto �6,   6<   .+�5      �� ��6    �� *
flightId+�� 5      $
��Left=�6>   $��	20,10,0,0q�6Y   $
��Wrap=�6l   $	��Top=�6�   $	��480��6�   $��30��6�   $��26(�6�   $��Calibri)�6�   $
��Bold"�6�   
���������6$   �� *
flightTB+6�   �� 5      $
��Left=�6?   $��
500,10,0,0q�6Z   $
��Wrap=�6n   $	��Top=�6�   $	��300��6�   $��30��6�   $��18(�6�   $��Calibri)�6�   
���������6$   �� *	depTimeTB+6�   �� 5      $
��Left=�6C   $��	20,50,0,0q�6^   $
��Wrap=�6q   $	��Top=�6�   $	��400��6�   $��20��6�   $��18(�6�   $��Calibri)�6�   
���������6$   �� *airlineNameTB+6�   �� 5       $
��Left=�6A   $��	20,80,0,0q�6\   $
��Wrap=�6o   $	��Top=�6�   $	��400��6�   $��20��6�   $��18(�6�   $��Calibri)�6�   
���������6$   �� *boardingATB+6�   5!      5"      5$      �� 5%   
   $1��+Забронированные билеты��6   $
��Left=�61   $��
225,10,0,0q�6L   $	��Top=�6`   $	��995��6x   $��60��6�   
�������$��Center=�6�   $��Center=�6�   $��20(�6�   5&      5'      