   M S B A M L   `   `   `  ����L  HUniversityJournal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:UniversityJournal.ViewModelUniversityJournal.ViewModel  5   	   (    "UniversityJournal.View.LoginScreen   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   7c)clr-namespace:UniversityJournal.ViewModel     5   	     � Title$  LoginScreen��5   	   $	��150��6   $	��300��6*    � 
ResizeMode$ NoResize=�66    � WindowStartupLocation$ CenterScreen=�6L    � WindowStyle$ 
ToolWindow=�6q    � 	Resources 5      0   *UniversityJournal.ViewModel.LoginConverter   LogConv��%   &	          5   
   6-   5	      .��5
      �  � RowDefinitions 5   
   �� 5      �� 5      $
��Auto �6   .+�5   
   � $��0��6   $��Center=�6   $��10q�67    5      �� 5      �� 5      �� 5       � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      .+�5      �� $��0��6   $��0��6%   $��
User name:��65   $��Right=�6G   $��Center=�6c   �� 5      $��1��6   $��0��6%   $��	Password:��65   $��Right=�6F   $��Center=�6b   �� 5      -   5         ��Name$ login��5   N   $��0��6   $��1��6#   $��Center=�63   6N   G� 5      -   5         G�Name$	 pwd��5   W   $��1��6   $��1��6'   	 G� PasswordChar$	 *��67   
 G� 	MaxLength$
 64��6H   6W   �� 5      -   5         ��Name$ 	InfoBlock��5   V   $��Center=�6   $��2��65   $��2��6B   $
��Wrap=�6i   $�� ��6}   $	��Top=�6�   5      � 5   
   $��1��6    5       �� 5!      �� 5"      .+�5$      �� -   5        $��Log In��5$      $��0��6&   $��75��5%      5&      �� 5'      $
��Exit��6   $��1��6$   $��75��5(       �� IsCancel . 5)      5*      5/      50      