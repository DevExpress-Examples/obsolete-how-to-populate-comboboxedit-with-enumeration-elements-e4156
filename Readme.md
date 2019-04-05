<!-- default file list -->
*Files to look at*:

* [MainWindow.xaml](./CS/S32737/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/S32737/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/S32737/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/S32737/MainWindow.xaml.vb))
<!-- default file list end -->
# OBSOLETE - How to populate ComboBoxEdit with enumeration elements


<p><strong>======================</strong><br /><strong>This article is now obsolete starting from 14.2. Refer to the <a href="https://www.devexpress.com/Support/Center/p/T196946">How to: Use EnumItemsSourceBehavior</a> ticket instead.</strong><br /><strong>======================</strong><br /><br />To bind ComboBoxEdit to an enum, use the EnumItemsSource markup extention in the following manner:</p>


```xaml
<dxe:ComboBoxEdit ItemsSource="{dxe:EnumItemsSource EnumType=local:MyEnum}"/>
```


<p><em>For version 13.1 and earlier:</em><br /> All logic is encapsulated in the BaseComboBoxStyleSettings descendant which is defined in the MyComboBoxStyleSettings.cs(vb) file. The representation of items in the popup window depends on the enumeration items kind. E.g., if enumeration items have description attributes they will display the description text instead of item names. If the enumeration definition is decorated with the FlagsAttribute attribute, items will be represented as check editors with the TextBlock element used as description.</p>

<br/>


