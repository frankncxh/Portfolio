
// Copyright
//DESIGNED BY: Frank.ZHOU 2020-04-21

<Window x:Class="JKY.Smartway.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:JKY.Smartway"
        mc:Ignorable="d"  WindowStartupLocation="CenterScreen" Loaded="Window_Loaded"
        Title="智慧公路采集控制客户端" Height="700" Width="1000" Closed="Window_Closed">

    <Window.Resources>
        <Style TargetType="TabControl">
            <Setter Property="FontSize" Value="20"/>
        </Style>
        <Style TargetType="Button">
            <Setter Property="Width" Value="60"></Setter>
            <Setter Property="Height" Value="40"></Setter>
        </Style>
    </Window.Resources>

    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="*"></RowDefinition>
            <RowDefinition Height="Auto"></RowDefinition>
        </Grid.RowDefinitions>
        <StackPanel Grid.Row="0" Height="30"   HorizontalAlignment="Right" VerticalAlignment="Top" Orientation="Horizontal" Margin="0,0,50,0" Panel.ZIndex="900">

            <CheckBox Name="ckb_Msg" Margin="0,0,30,0"  VerticalAlignment="Center" VerticalContentAlignment="Center" Click="CheckBox_Click" IsChecked="True">收集实时信息</CheckBox>
            <CheckBox Name="ckb_Msg_Ctr" VerticalAlignment="Center" VerticalContentAlignment="Center" Click="CheckBox_Ctr_Click" IsChecked="False">只查看控制信息</CheckBox>
            <Button Margin="20,0,0,0" Width="50" Height="25" Click="btn_Lock_Click">锁屏</Button>
        </StackPanel>
        <TabControl Grid.Row="0" >
            <TabItem Header="运行监控">
                <Grid Background="#B1D3EC">
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="63*"/>
                        <ColumnDefinition Width="13*"/>
                        <ColumnDefinition Width="417*"/>
                    </Grid.ColumnDefinitions>
                    <Grid.RowDefinitions>
                        <RowDefinition Height="Auto"></RowDefinition>
                        <RowDefinition Height="*"></RowDefinition>
                    </Grid.RowDefinitions>
                    <StackPanel Margin="5" Grid.Row="0" Orientation="Horizontal" Grid.ColumnSpan="3">                     
                        <Button Name="btn_AppStart" Margin="10,0,0,0" Click="Button_AppStart_Click">启动</Button>
                        <Button Name="btn_AppStop" Margin="10,0,0,0" Click="Button_AppStop_Click" IsEnabled="False">停止</Button>

                    </StackPanel>
                    <RichTextBox Name="rtb_Message" Grid.Row="1" VerticalScrollBarVisibility="Auto" Grid.ColumnSpan="3">
                        <RichTextBox.Document>
                            <FlowDocument Focusable="True" LineHeight="1"></FlowDocument>
                        </RichTextBox.Document>
                    </RichTextBox>
                </Grid>
            </TabItem>
            <TabItem Header="采集信息">
                <Grid  Background="#FFECBF">
                    <TabControl Margin="0,10"  SelectionChanged="SensorData_SelectionChanged">
                        <TabItem Header="结冰" Name="IceItem">
                            <ListView  Name="lv_IceInfos" Grid.Row="1" Margin="5,0,5,5" Background="AliceBlue" ScrollViewer.HorizontalScrollBarVisibility="Auto"  ScrollViewer.VerticalScrollBarVisibility="Auto">
                                <ListView.View>
                                    <GridView>
                                        <GridViewColumn Header="设备ID  " DisplayMemberBinding="{Binding Path=DeviceID,Mode=OneWay}" />
                                        <GridViewColumn Header="设备位置   " DisplayMemberBinding="{Binding Path=DeviceAdr,Mode=OneWay}" />
                                        <GridViewColumn Header="是否结冰   " DisplayMemberBinding="{Binding Path=IsIceStr,Mode=OneWay}" />
                                        <GridViewColumn Header="结冰厚度   " DisplayMemberBinding="{Binding Path=Thickness,Mode=OneWay}" />
                                        <GridViewColumn Header="温度       " DisplayMemberBinding="{Binding Path=Temperature,StringFormat='0.00',Mode=OneWay}" />
                                        <GridViewColumn Header="采集时间  " DisplayMemberBinding="{Binding Path=CTime,StringFormat='yyyy-MM-dd HH:mm',Mode=OneWay}" />
                                    </GridView>
                                </ListView.View>
                            </ListView>
                        </TabItem>

                        <TabItem Header="风速风向"  Name="FsyItem">
                            <ListView  Name="lv_FsyInfos" Grid.Row="1" Margin="5,0,5,5" Background="AliceBlue" ScrollViewer.HorizontalScrollBarVisibility="Auto"  ScrollViewer.VerticalScrollBarVisibility="Auto">
                                <ListView.View>
                                    <GridView>
                                        <GridViewColumn Header="设备ID  " DisplayMemberBinding="{Binding Path=DeviceID,Mode=OneWay}" />
                                        <GridViewColumn Header="设备位置   " DisplayMemberBinding="{Binding Path=DeviceAdr,Mode=OneWay}" />
                                        <GridViewColumn Header="风速   " DisplayMemberBinding="{Binding Path=Speed,Mode=OneWay}" />
                                        <GridViewColumn Header="风向   " DisplayMemberBinding="{Binding Path=Direction,Mode=OneWay}" />
                                        <GridViewColumn Header="采集时间  " DisplayMemberBinding="{Binding Path=CTime,StringFormat='yyyy-MM-dd HH:mm',Mode=OneWay}" />
                                    </GridView>
                                </ListView.View>
                            </ListView>
                        </TabItem>
                        <TabItem Header="温湿度"  Name="HumitureItem">
                            <ListView  Name="lv_HumitureInfos" Grid.Row="1" Margin="5,0,5,5" Background="AliceBlue" ScrollViewer.HorizontalScrollBarVisibility="Auto"  ScrollViewer.VerticalScrollBarVisibility="Auto">
                                <ListView.View>
                                    <GridView>
                                        <GridViewColumn Header="设备ID  " DisplayMemberBinding="{Binding Path=DeviceID,Mode=OneWay}" />
                                        <GridViewColumn Header="设备位置   " DisplayMemberBinding="{Binding Path=DeviceAdr,Mode=OneWay}" />
                                        <GridViewColumn Header="温度   " DisplayMemberBinding="{Binding Path=Temperature,Mode=OneWay}" />
                                        <GridViewColumn Header="湿度   " DisplayMemberBinding="{Binding Path=Humiture,Mode=OneWay}" />
                                        <GridViewColumn Header="采集时间  " DisplayMemberBinding="{Binding Path=CTime,StringFormat='yyyy-MM-dd HH:mm',Mode=OneWay}" />
                                    </GridView>
                                </ListView.View>
                            </ListView>
                        </TabItem>
                        <TabItem Header="能见度"  Name="VisibleItem">
                            <ListView  Name="lv_VisibleInfos" Grid.Row="1" Margin="5,0,5,5" Background="AliceBlue" ScrollViewer.HorizontalScrollBarVisibility="Auto"  ScrollViewer.VerticalScrollBarVisibility="Auto">
                                <ListView.View>
                                    <GridView>
                                        <GridViewColumn Header="设备ID  " DisplayMemberBinding="{Binding Path=DeviceID,Mode=OneWay}" />
                                        <GridViewColumn Header="设备位置   " DisplayMemberBinding="{Binding Path=DeviceAdr,Mode=OneWay}" />
                                        <GridViewColumn Header="能见度  " DisplayMemberBinding="{Binding Path=VisibleLength,Mode=OneWay}" />
                                        <GridViewColumn Header="采集时间  " DisplayMemberBinding="{Binding Path=CTime,StringFormat='yyyy-MM-dd HH:mm',Mode=OneWay}" />
                                    </GridView>
                                </ListView.View>
                            </ListView>
                        </TabItem>
                        <TabItem Header="倾斜"  Name="TiltItem">
                            <ListView  Name="lv_TiltInfos" Grid.Row="1" Margin="5,0,5,5" Background="AliceBlue" ScrollViewer.HorizontalScrollBarVisibility="Auto"  ScrollViewer.VerticalScrollBarVisibility="Auto">
                                <ListView.View>
                                    <GridView>
                                        <GridViewColumn Header="设备ID  " DisplayMemberBinding="{Binding Path=DeviceID,Mode=OneWay}" />
                                        <GridViewColumn Header="设备位置   " DisplayMemberBinding="{Binding Path=DeviceAdr,Mode=OneWay}" />
                                        <GridViewColumn Header="是否倾斜   " DisplayMemberBinding="{Binding Path=IsTiltStr,Mode=OneWay}" />
                                        <GridViewColumn Header="采集时间  " DisplayMemberBinding="{Binding Path=CTime,StringFormat='yyyy-MM-dd HH:mm',Mode=OneWay}" />
                                    </GridView>
                                </ListView.View>
                            </ListView>
                        </TabItem>
                        <TabItem Header="水位(控制)"  Name="WaterCtrItem">
                            <ListView  Name="lv_WaterCtrInfos" Grid.Row="1" Margin="5,0,5,5" Background="AliceBlue" ScrollViewer.HorizontalScrollBarVisibility="Auto"  ScrollViewer.VerticalScrollBarVisibility="Auto">
                                <ListView.View>
                                    <GridView>
                                        <GridViewColumn Header="设备ID  " DisplayMemberBinding="{Binding Path=DeviceID,Mode=OneWay}" />
                                        <GridViewColumn Header="IP " DisplayMemberBinding="{Binding Path=IP,Mode=OneWay}" />
                                        <GridViewColumn Header="Port   " DisplayMemberBinding="{Binding Path=Port,Mode=OneWay}" />
                                        <GridViewColumn Header="水位   " DisplayMemberBinding="{Binding Path=PhysicalValue,Mode=OneWay}" />
                                        <GridViewColumn Header="采集时间  " DisplayMemberBinding="{Binding Path=CTime,StringFormat='yyyy-MM-dd HH:mm',Mode=OneWay}" />
                                    </GridView>
                                </ListView.View>
                            </ListView>
                        </TabItem>
                        <TabItem Header="结冰(控制)"  Name="IceCtrItem">
                            <ListView  Name="lv_IceCtrInfos" Grid.Row="1" Margin="5,0,5,5" Background="AliceBlue" ScrollViewer.HorizontalScrollBarVisibility="Auto"  ScrollViewer.VerticalScrollBarVisibility="Auto">
                                <ListView.View>
                                    <GridView>
                                        <GridViewColumn Header="设备ID  " DisplayMemberBinding="{Binding Path=DeviceID,Mode=OneWay}" />
                                        <GridViewColumn Header="IP " DisplayMemberBinding="{Binding Path=IP,Mode=OneWay}" />
                                        <GridViewColumn Header="Port   " DisplayMemberBinding="{Binding Path=Port,Mode=OneWay}" />
                                        <GridViewColumn Header="编号   " DisplayMemberBinding="{Binding Path=IceIndex,Mode=OneWay}" />
                                        <GridViewColumn Header="是否结冰   " DisplayMemberBinding="{Binding Path=IsIceStr,Mode=OneWay}" />
                                        <GridViewColumn Header="结冰厚度   " DisplayMemberBinding="{Binding Path=Thickness,Mode=OneWay}" />
                                        <GridViewColumn Header="温度       " DisplayMemberBinding="{Binding Path=Temperature,StringFormat='0.00',Mode=OneWay}" />
                                        <GridViewColumn Header="采集时间  " DisplayMemberBinding="{Binding Path=CTime,StringFormat='yyyy-MM-dd HH:mm',Mode=OneWay}" />
                                    </GridView>
                                </ListView.View>
                            </ListView>
                        </TabItem>
                    </TabControl>
                </Grid>

            </TabItem>
            <TabItem Header="融冰控制">
                <Grid Background="#FFECBF">
                    <ListView  Name="lv_OptInfos" Grid.Row="1" Margin="5,0,5,5" Background="AliceBlue" ScrollViewer.HorizontalScrollBarVisibility="Auto"  ScrollViewer.VerticalScrollBarVisibility="Auto">

                        <ListView.View>
                            <GridView>
                                <GridViewColumn Header="操作IP  " DisplayMemberBinding="{Binding Path=IP,Mode=OneWay}" />
                                <GridViewColumn Header="Port  " DisplayMemberBinding="{Binding Path=Port,Mode=OneWay}" />
                                <GridViewColumn Header="操作模式   " DisplayMemberBinding="{Binding Path=Mode,Mode=OneWay}" />
                                <GridViewColumn Header="当前状态   " DisplayMemberBinding="{Binding Path=Status,Mode=OneWay}" />
                                <GridViewColumn Header="更新时间  " DisplayMemberBinding="{Binding Path=CTime,StringFormat='yyyy-MM-dd HH:mm',Mode=OneWay}" />
                                <!--<GridViewColumn Header="结束时间  " DisplayMemberBinding="{Binding Path=EndTime,StringFormat='yyyy-MM-dd HH:mm',Mode=OneWay}" />-->
                            </GridView>
                        </ListView.View>
                    </ListView>
                </Grid>
            </TabItem>
            <TabItem Header="排水控制">
                <Grid Background="#FFECBF">
                    <ListView  Name="lv_WaterClearInfos" Grid.Row="1" Margin="5,0,5,5" Background="AliceBlue" ScrollViewer.HorizontalScrollBarVisibility="Auto"  ScrollViewer.VerticalScrollBarVisibility="Auto">

                        <ListView.View>
                            <GridView>
                                <GridViewColumn Header="操作IP  " DisplayMemberBinding="{Binding Path=IP,Mode=OneWay}" />
                                <GridViewColumn Header="Port  " DisplayMemberBinding="{Binding Path=Port,Mode=OneWay}" />
                                <GridViewColumn Header="操作模式   " DisplayMemberBinding="{Binding Path=Mode,Mode=OneWay}" />
                                <GridViewColumn Header="当前状态   " DisplayMemberBinding="{Binding Path=Status,Mode=OneWay}" />
                                <GridViewColumn Header="更新时间  " DisplayMemberBinding="{Binding Path=CTime,StringFormat='yyyy-MM-dd HH:mm',Mode=OneWay}" />
                                <!--<GridViewColumn Header="结束时间  " DisplayMemberBinding="{Binding Path=EndTime,StringFormat='yyyy-MM-dd HH:mm',Mode=OneWay}" />-->
                            </GridView>
                        </ListView.View>
                    </ListView>
                </Grid>
            </TabItem>
            <TabItem Header="维护信息">
                <Grid Background="#FFECBF">
                    <ListView  Name="lv_RepairInfos" Grid.Row="1" Margin="5,0,5,5" Background="AliceBlue" ScrollViewer.HorizontalScrollBarVisibility="Auto"  ScrollViewer.VerticalScrollBarVisibility="Auto">

                        <ListView.View>
                            <GridView>
                                <GridViewColumn Header="维护IP  " DisplayMemberBinding="{Binding Path=IP,Mode=OneWay}" />
                                <GridViewColumn Header="Port  " DisplayMemberBinding="{Binding Path=Port,Mode=OneWay}" />
                                <GridViewColumn Header="当前状态   " DisplayMemberBinding="{Binding Path=Status,Mode=OneWay}" />
                                <GridViewColumn Header="更新时间  " DisplayMemberBinding="{Binding Path=CTime,StringFormat='yyyy-MM-dd HH:mm',Mode=OneWay}" />
                                <!--<GridViewColumn Header="结束时间  " DisplayMemberBinding="{Binding Path=EndTime,StringFormat='yyyy-MM-dd HH:mm',Mode=OneWay}" />-->
                            </GridView>
                        </ListView.View>
                    </ListView>
                </Grid>
            </TabItem>
            <!--<TabItem Header="配置信息">
                <Grid>
                    <Grid.RowDefinitions>
                        <RowDefinition Height="Auto"></RowDefinition>
                        <RowDefinition Height="Auto"></RowDefinition>
                        <RowDefinition Height="*"></RowDefinition>
                    </Grid.RowDefinitions>

                </Grid>
            </TabItem>-->
        </TabControl>

        <StackPanel Grid.Row="1" Orientation="Horizontal"  >
            <StackPanel.Resources>
                <Style TargetType="Button">
                    <Setter Property="Margin" Value="5"></Setter>
                </Style>
            </StackPanel.Resources>
            <Button Click="UpdateCache_click">刷新缓存</Button>
        </StackPanel>

        <StackPanel Grid.Row="1" Orientation="Horizontal" IsEnabled="False" Visibility="Collapsed" >
            <StackPanel.Resources>
                <Style TargetType="Button">
                    <Setter Property="Margin" Value="5"></Setter>
                </Style>
            </StackPanel.Resources>
            <Button Click="Test_Click">发送模拟数据</Button>
            <Button Click="TestHardCmdStart_Click">控制融雪开始</Button>
            <Button Click="TestHardCmdStart_Clear_Click">控制排水开始</Button>
            <Button Click="TestHardCmdStart_Water_Click">控制获取水位</Button>
            <Button Click="TestHardCmdStart_Health_Click">控制获取健康</Button>
            <Button Click="Test_Cmd_Click" Tag="F6">融雪开始</Button>
            <Button Click="Test_Cmd_Click" Tag="F8">融雪结束</Button>
            <Button Click="Test_Cmd_Click" Tag="F7">排空开始</Button>
            <Button Click="Test_Cmd_Click" Tag="F9">排空结束</Button>
            <Button Click="Test_Cmd_Click" Tag="FB">维护开始</Button>
            <Button Click="Test_Cmd_Click" Tag="FC">维护结束</Button>
            <Button Click="Test_WeChat_Click">微信推送</Button>
            <CheckBox Name="ckb_SendLive" VerticalAlignment="Center" VerticalContentAlignment="Center" Click="ckb_SendLive_Click" >发送在线模拟</CheckBox>
            
        </StackPanel>
        
    </Grid>
</Window>

