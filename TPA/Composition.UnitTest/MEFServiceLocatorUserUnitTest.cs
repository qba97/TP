﻿
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPA.Composition.UnitTest.CommonServiceLocatorInstrumentation;

namespace TPA.Composition.UnitTest
{
  [TestClass]
  public class MEFServiceLocatorUserUnitTest
  {
    [TestMethod]
    public void NoCompositionTestMethod1()
    {
      MEFServiceLocatorUser _newInstance = new MEFServiceLocatorUser();
      Assert.IsNull(_newInstance.Logger);
    }
    [TestMethod]
    public void CompositionTestMethod1()
    {
      MEFServiceLocatorUser _newInstance = new MEFServiceLocatorUser();
      ComposeParts(_newInstance);
      Assert.IsNotNull(_newInstance.Logger);
      _newInstance.DataProcessing();
    }
    private void ComposeParts(object attributedParts)
    {
      //An aggregate catalog that combines multiple catalogs
      AggregateCatalog _catalog = new AggregateCatalog();
      //Create the CompositionContainer with the parts in the catalog
      _catalog.Catalogs.Add(new DirectoryCatalog(Path.GetDirectoryName(typeof(MEFServiceLocatorUserUnitTest).Assembly.Location)));
      m_Container = new CompositionContainer(_catalog);
      //Fill the imports of this object
      m_Container.ComposeParts(attributedParts);
    }
    private CompositionContainer m_Container = null;
  }
  [Export(typeof(ILogger))]
  public class MEFILogger : Logger { }

}
