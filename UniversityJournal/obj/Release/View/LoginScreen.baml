   M S B A M L   `   `   `  ���� L  HUniversityJournal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:UniversityJournal.ViewModelUniversityJournal.ViewModel  (    "UniversityJournal.View.LoginScreen   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     7c)clr-namespace:UniversityJournal.ViewModel       � Title$  LoginScreen��$	��150��$	��300�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � WindowStyle$ 
ToolWindow=� � 	Resources 0   *UniversityJournal.ViewModel.LoginConverter   LogConv��%   &	          .���  � RowDefinitions �� �� $
��Auto �.+�� $��0��$��Center=�$��10q� �� �� ��  � ColumnDefinitions �� $
��Auto ��� .+��� $��0��$��0��$��
User name:��$��Right=�$��Center=��� $��1��$��0��$��	Password:��$��Right=�$��Center=��� -    ��Name$ login��$��0��$��1��$��Center=�G� -    G�Name$	 pwd��$��1��$��1��	 G� PasswordChar$	 *��
 G� 	MaxLength$
 64���� -    ��Name$ 	InfoBlock��$��Center=�$��2��$��2��$
��Wrap=�$�� ��$	��Top=�� $��1�� �� �� .+��� -   $��Log In��$��0��$��75���� $
��Exit��$��1��$��75�� �� IsCancel . 