**************************************************
Learning Attributes
**************************************************

**************************************************
هر متن دیگری جز اطلاعات ذیل در فایل
Resources.csproj
وجود داشته باشد، یا خطا می‌دهد و یا عمل نمی‌کند

	<ItemGroup>
		<Compile Update="DataDictionary.Designer.cs">
			<DesignTime>True</DesignTime>
			<AutoGen>True</AutoGen>
			<DependentUpon>DataDictionary.resx</DependentUpon>
		</Compile>
		<Compile Update="Messages\Validations.Designer.cs">
			<DesignTime>True</DesignTime>
			<AutoGen>True</AutoGen>
			<DependentUpon>Validations.resx</DependentUpon>
		</Compile>
	</ItemGroup>

	<ItemGroup>
		<EmbeddedResource Update="DataDictionary.resx">
			<Generator>PublicResXFileCodeGenerator</Generator>
			<LastGenOutput>DataDictionary.Designer.cs</LastGenOutput>
		</EmbeddedResource>
		<EmbeddedResource Update="Messages\Validations.resx">
			<Generator>PublicResXFileCodeGenerator</Generator>
			<LastGenOutput>Validations.Designer.cs</LastGenOutput>
		</EmbeddedResource>
	</ItemGroup>
**************************************************
