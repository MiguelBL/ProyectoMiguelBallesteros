   M S B A M L   `   `   `  ����[  WProyecto Miguel Ballesteros 2023, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Proyecto_Miguel_Ballesteros_2023 Proyecto_Miguel_Ballesteros_2023  5   	   3    -Proyecto_Miguel_Ballesteros_2023.GestionUsers   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @local.clr-namespace:Proyecto_Miguel_Ballesteros_2023     5   	     � Title$  GestionUsers��5   	   $	��450��6   $	��800��6+   .��5	      � .+�5
   
   �� $'��!Assets/farmacia-productos-728.png��6   $��UniformToFill=�6;   �� 5   
   -   5         ��Name$ 
LVUsuarios��5      $	��300��6'   $��240,60,31.6,0q�64   $	��Top=�6K   
���   �$��2q�6w   $��	Bodoni MT)�6�    �� View 5      �� 5      .P�5      �� $��Nombre��6%    �� Width$	 170��6]    �� DisplayMemberBinding 65   �� *nombre+6]   �� 5      $��	Direccion��6%   $	 180��6`    68   �� *adress+6`   �� 5      $��Telefono��6%   $ 80��6^    67   �� *phone+6^   �� 5      $	��Rol��6%   $ 85��6W    62   �� *rol+6W   5      5      �� 5   
   
�������$
��Left=�6!   $��
11,10,0,10q�6<   
���   �$��3��6_   $	��211��6s   �� 5   
   $��Nombre��6   $
��Left=�6!   $��31��6<   $��	11,27,0,0q�6H   $	��Top=�6[   $	��211��6s   $��Center=�6   $��Center=�6�   $��	Bodoni MT)�6�   $
��Bold"�6�   �� 5   
   -   5         ��Name$ 	TxtNombre��5      $
��Left=�6%   $��53��6@   $��	25,60,0,0q�6L    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��183��6�   $��Center=�6�   $��	Bodoni MT)�6�   �� 5   
   $��
Dirección��6   $
��Left=�6$   $��31��6?   $��
11,119,0,0q�6K   $	��Top=�6_   $	��211��6w   $��Center=�6�   $��Center=�6�   $��	Bodoni MT)�6�   $
��Bold"�6�   �� 5   
   -   5        $ TxtDireccion��5      $
��Left=�6(   $��53��6C   $��
25,151,0,0q�6O   $
 Wrap=�6c   $	��Top=�6w   $	��183��6�   $��Center=�6�   $��	Bodoni MT)�6�   �� 5   
   $��	Teléfono��6   $
��Left=�6#   $��31��6>   $��
11,211,0,0q�6J   $	��Top=�6^   $	��211��6v   $��Center=�6�   $��Center=�6�   $��	Bodoni MT)�6�   $
��Bold"�6�   �� 5   
   -   5        $ TxtTelefono��5      $
��Left=�6'   $��30��6B   $��
25,242,0,0q�6N   $
 Wrap=�6b   $	��Top=�6v   $	��183��6�   $��Center=�6�   $��Center=�6�   $��	Bodoni MT)�6�   �� 5   
   $	��Rol��6   $
��Left=�6   $��31��69   $��
11,280,0,0q�6E   $	��Top=�6Y   $	��211��6q   $��Center=�6}   $��Center=�6�   $��	Bodoni MT)�6�   $
��Bold"�6�   �� 5   
   -   5         ��Name$ CBRol��5      $
��Left=�6"   $��32��6=   $��
25,311,0,0q�6I   $	��Top=�6]   $	��183��6u   $��	Bodoni MT)�6�   
���   ���5      �� 5        �� EndPoint$	 0,1&�6&   	 �� 
StartPoint$		 0,0&�65   .��5!      � 
 � Color$
 	#FFF0F0F0��6#    � Offset$ 0Q�65   � 5"      $
 White��6#   $ 1Q�61   5#      5%      �� 5&   
   -   5         ��Name$ BTSave��5&      $��Guardar��6!   $
��Left=�63   $��29��6N   $��
25,361,0,0q�6Z   $	��Top=�6n   $	��183��6�   ���	#FF5F99D9$��	Bodoni MT)�6�   $
��Bold"�6�   $��16(�6�   ��5'      �� 5(       �� 
TargetType" ��6"   .R�5)      �� #��z��6   #��z��5*      #��z��5+       �� CornerRadius$ 20��5,      ._�5-      �� $��Center=�6+   $��Center=�5.   #   5/      50      52      �� 53   
   -   5        $ 	BTNewUser��53      $��Nuevo usuario��6$   $��31��6<   $��0,0,222.6,12q�6H   $��Bottom=�6^   $��	Bodoni MT)�6y   $
��Bold"�6�   
���   �
�������$��16(�6�   $��Right=�6�   $	��166��6  ��54      �� 55      " ��6"   .R�56      �� #��z��6   #��z��57      #��z��58      $ 20��59      ._�5:      �� $��Center=�6+   $��Center=�5;   #   5<      5=      5?      �� 5@   
   ���	#FFF4F4F5$��Right=�6%   $��33��6A   $��	0,0,0.6,0q�6M   
���   �$	��Top=�6o   $	��332��6�   �� 5A   
   -   5         ��Name$ LblUser��5A      $�� ��6!   $��33��6,   $��	0,0,0.6,0q�68   $	��Top=�6K   $��	Bodoni MT)�6c   $
��Bold"�6z   $��Center=�6�   $��Center=�6�   $��Right=�6�   $	��332��6�   �� 5B   
   -	   5        $ LblEmail��5B      $��Label��6"   $
��Left=�62   $��30��6M   $��280,390,0,0q�6Y   $	��Top=�6n   $	��226��6�   $y�Hidden=�6�   �� 5C   
   -
   5        $ TxtEmail��5C      $
��Left=�6$   $��23��6?   $��	11,10,0,0q�6K   $
 Wrap=�6^   $	��Top=�6r   $	��211��6�   $y�Hidden=�6�   �� 5D   
   -   5        $ LblEmailUser��5D      $��Label��6&   $
��Left=�66   $��30��6Q   $��267,390,0,0q�6]   $	��Top=�6r   $	��153��6�   $y�Hidden=�6�   �� 5E   
   -   5        $ 	BTRefresh��5E      $��Actualizar lista��6$   $��31��6?   $��0,0,31.6,12q�6K   $��Bottom=�6`   $��	Bodoni MT)�6{   $
��Bold"�6�   
���   �
�������$��16(�6�   $��Right=�6�   $	��166��6  ��5F      �� 5G      " ��6"   .R�5H      �� #��z��6   #��z��5I      #��z��5J      $ 20��5K      ._�5L      �� $��Center=�6+   $��Center=�5M      5N      5O      5Q      �� 5R   
   -   5        $ LblRol��5R      $��Label��6    $
��Left=�60   $��47��6K   $��242,373,0,0q�6W   $	��Top=�6l   $	��163��6�   $y�Hidden=�6�   5T      5U      