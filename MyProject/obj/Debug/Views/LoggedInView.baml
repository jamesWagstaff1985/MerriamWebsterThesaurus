   M S B A M L   `   `   `  ����D  @MyProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:MyProject.ViewsMyProject.Views  5   	   "    MyProject.Views.LoggedInView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:MyProject.Views     5   	     � Title$  Synonyms and Antonyms��5   	   $	��450��6'   $	��800��64   .��5	      � $��20q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $3��-Enter a word to get all Synonyms and Antonyms��6   $��0��6I   $��0��6V   $��Center=�6f   �� 5   
   -   5         ��Name$
 Word��5      $��0��6    $��1��6-   $��10q�6=   $	��200��6I   $
��Left=�6U   �� 5   
   $��Synonyms��6   $��1��6$   $��0��61   $��10q�6A   �� 5   
   -   5         ��Name$ ReturnedSynonyms��5      $��1��6.   $��1��6;   $��10q�6K   $
��Wrap=�6W   $	��450��6k   �� 5   
   $��Antonyms��6   $��2��6$   $��0��61   $��10q�6A   �� 5   
   -   5        $ ReturnedAntonyms��5      $��2��6.   $��1��6;   $��10q�6K   $
��Wrap=�6W   $	��450��6k   5      5      