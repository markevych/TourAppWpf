   M S B A M L   `   `   `  ����B  >TourApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:TourAppTourApp  5   	       TourApp.UpdateRouteWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:TourApp     5   	     � Title$  Редагування��5   	   $	��522��6   $	��526��6*   .��5	      � .+�5
   
   �� $-��'Країна відправлення :��6   $
��Left=�60   $��	14,15,0,0q�6K   $	��Top=�6^   �� 5   
   $+��%Місто відправлення :��6   $
��Left=�6/   $��	13,66,0,0q�6J   $	��Top=�6]   �� 5   
   $%��Країна прибуття :��6   $
��Left=�6,   $��
14,117,0,0q�6G   $	��Top=�6[   �� 5   
   $#��Місто прибуття :��6   $
��Left=�6+   $��
13,168,0,0q�6F   $	��Top=�6Z   �� 5   
   $'��!Час відправлення :��6   $
��Left=�6-   $��
14,219,0,0q�6H   $	��Top=�6\   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��startDatePicker��5   h   $
��Left=�6   $��
14,250,0,0q�60   $	��Top=�6D   $	��414��6\   6h   �� 5   
   $'��!Час відправлення :��6   $
��Left=�6-   $��
13,279,0,0q�6H   $	��Top=�6\     5   
   -   5        $��endDatePicker��5   i   $
��Left=�6   $��
13,310,0,0q�60   $	��Top=�6D   $	��414��6\   6i   �� 5   
   $��
Ціна :��6   $
��Left=�6!   $��
14,339,0,0q�6<   $	��Top=�6P   �� 5   
   -   5        $��
priceInput��5   �   $
��Left=�6   $��
13,370,0,0q�6-    �� TextWrapping$
 Wrap=�6A   $	��Top=�6U   $	��493��6m   $��23��6y   6�   �� 5   
   -   5        $��Внести зміни��5      $
��Left=�6(   $��
13,427,0,0q�6C   $	��Top=�6W   $��34��6o   $	��206��6{   6�   �� 5   
   -   5        $��Видалити��5      $
��Left=�6$   $��300,427,0,0q�6?   $	��Top=�6T   $��34��6l   $	��206��6x   6�   �� 5   
   -   5        $��fromCountriesList��5   q   $
��Left=�6   $��	14,41,0,0q�6.   $	��Top=�6A   $	��492��6Y   $��20��6e   6�   �� 5   
   -   5        $��fromCitiesList��5   q   $
��Left=�6   $��	14,92,0,0q�6.   $	��Top=�6A   $	��492��6Y   $��20��6e   6q   �� 5   
   -   5        $��toCountriesList��5   r   $
��Left=�6   $��
14,143,0,0q�6.   $	��Top=�6B   $	��492��6Z   $��20��6f   6�   �� 5   
   -	   5        $��toCitiesList��5   r   $
��Left=�6   $��
14,194,0,0q�6.   $	��Top=�6B   $	��492��6Z   $��20��6f   6r   5      5      