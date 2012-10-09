using System;
using Testable;
using UnityEngine;
using System.IO;
using System.Xml.Linq;
using Ninject;
using Moq;

namespace Tests {
    public class MockResourceLoader : Testable.IResourceLoader {

        private string resourcesPath = Path.GetFullPath("../../../../Assets/resources");
        private IKernel kernel;

        public MockResourceLoader(IKernel kernel) {
            this.kernel = kernel;
        }

        public Material loadMaterial(string path) {
            string filepath = Path.Combine(resourcesPath, path);
            if (exists(filepath)) {
                return null;
            }

            throw new FileNotFoundException (path);
        }

        public AudioClip loadClip(string path) {

            string filepath = Path.Combine(resourcesPath, path);

            if (exists(filepath)) {
                return new AudioClip ();
            }

            throw new FileNotFoundException (path);
        }

        public XDocument loadDoc(string path) {
            path += ".xml";
            return XDocument.Load(Path.Combine(resourcesPath, path));
        }

        public TestableGameObject instantiate(string path) {
            path += ".prefab";
            string filepath = Path.Combine(resourcesPath, path);
            FileInfo file = new FileInfo (filepath);
            if (file.Exists) {
                return kernel.Get<TestableGameObject>();
            }

            throw new FileNotFoundException (path);
        }

        private static bool exists(string filepath) {
            FileInfo file = new FileInfo (filepath + ".ogg");
            if (file.Exists) {
                return true;
            }

            file = new FileInfo (filepath + ".wav");
            if (file.Exists) {
                return true;
            }

            file = new FileInfo (filepath + ".mat");
            if (file.Exists) {
                return true;
            }

            return false;
        }
    }
}

