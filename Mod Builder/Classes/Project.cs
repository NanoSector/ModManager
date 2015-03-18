using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mod_Builder.Classes.ProjectComponents;
using System.Xml.Serialization;

namespace Mod_Builder.Classes
{
    [Serializable()]
    public class Project
    {
        public List<Instruction.InstructionBase> instructions;
        public string name = "";
        public string version = "";
        public string username = "";
        public string modID = "";
        public bool generateModID = true;
        public string compatibility;
        public Settings settings = new Settings();

        [XmlIgnore] public bool isOnDisk = false;
        [XmlIgnore]
        public string filename
        {
            get
            {
                if (!this.isOnDisk)
                    throw new ProjectNotOnDiskException("The project is not saved on disk, therefore no filename is set.");

                return filename;
            }
            set
            {
                filename = value;
            }
        }

        /**
         * <summary>Sets flags so the project appears to be on a disk or other storage medium. Will attempt to create the file if it does not exist.</summary>
         * <param name="filename">The file to set the project to.</param>
         * <exception cref="Mod_Builder.Classes.ProjectAlreadyOnDiskException">Thrown when the project is already on a disk.</exception>
         */
        public void moveToDisk(string filename)
        {
            // Check the filename.

        }

        /**
         * <summary>Sets flags so the project appears to be moved to memory. Can also attempt to delete the file. associated.</summary>
         * <param name="delete">Switch to attempt to delete the file associated.</param>
         * <exception cref="Mod_Builder.Classes.ProjectAlreadyInMemoryException">Thrown when the project is already in memory.</exception>
         */
        public void moveToMemory(bool delete = false)
        {
            // Already in memory?
            if (!this.isOnDisk)
                throw new ProjectAlreadyInMemoryException();

            // Invalidate the file name and set the isOnDisk flag to false.
            this.filename = "";
            this.isOnDisk = false;
        }
    }

    public class ProjectNotOnDiskException : Exception
    {
        public ProjectNotOnDiskException()
        {
        }

        public ProjectNotOnDiskException(string message)
            : base(message)
        {
        }

        public ProjectNotOnDiskException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
    public class ProjectAlreadyOnDiskException : Exception
    {
        public ProjectAlreadyOnDiskException()
        {
        }

        public ProjectAlreadyOnDiskException(string message)
            : base(message)
        {
        }

        public ProjectAlreadyOnDiskException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
    public class ProjectAlreadyInMemoryException : Exception
    {
        public ProjectAlreadyInMemoryException()
        {
        }

        public ProjectAlreadyInMemoryException(string message)
            : base(message)
        {
        }

        public ProjectAlreadyInMemoryException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
