   M S B A M L   `   `   `  ����A  =Enigma, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:EnigmaEnigma  5   	       Enigma.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Enigma     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��538��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5      .+�5   
   �� -   5         ��Name$ textBox��5      $��Center=�6#   $��0,85,0,0q�6@    �� TextWrapping$
 Wrap=�6R   $	��Top=�6f   $	��208��6~   $	��132��6�   �� 5   
   -   5         ��Name$ 
label_text��5      $
��Text��6$   $
��Left=�63   $��	30,59,0,0q�6N   $	��Top=�6a   $	��120��6y   �� 5   
   -   5        $ label_Encrypt_Decrypt��5      $��Encrypt/Decrypt��6/   $
��Left=�6I   $��	31,59,0,0q�6d   $	��Top=�6w   $	��180��6�   $��1��6�   �� 5   
   -   5         ��Name$ buttonEncrypt��5      $��Encrypt��6(   $
��Left=�6:   $��
25,268,0,0q�6U   $	��Top=�6i   $��62��6�   $	��213��6�   $��Segoe UI Semibold)�6�   $��18(�6�   ��5      �� 5       �� ImageSource$" /button backgruond green.jpg��6   5      �� 5   
   -   5        $ buttonDecrypt��5      $��Decrypt��6(   $��Center=�6:   $��	0,268,0,0q�6W   $	��Top=�6j   $��62��6�   $	��213��6�   $��Segoe UI Semibold)�6�   $��18(�6�   $��1��6�   ��5      �� 5      $# /button backgruond orange.jpg��6   5      �� 5   
   -   5        $ textBox_EncryptDecrypt��5      $��Center=�62   $��0,85,0,0q�6O   $
 Wrap=�6a   $	��Top=�6u   $	��208��6�   $	��132��6�   $��1��6�    �� 
IsReadOnly . 6�   5      5      