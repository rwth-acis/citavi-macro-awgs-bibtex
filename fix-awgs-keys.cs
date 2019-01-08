using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Forms;

using SwissAcademic.Citavi;
using SwissAcademic.Citavi.Metadata;
using SwissAcademic.Citavi.Shell;
using SwissAcademic.Collections;

// Implementation of macro editor is preliminary and experimental.
// The Citavi object model is subject to change in future version.

public static class CitaviMacro
{
	public static void Main()
	{
		
		List<Reference> references = Program.ActiveProjectShell.PrimaryMainForm.GetFilteredReferences();
		
		//if we need a ref to the active project
		SwissAcademic.Citavi.Project activeProject = Program.ActiveProjectShell.Project;
		
		foreach (Reference reference in references)
		{
			if (reference.Authors.Count == 3)
			{
				// just to be sure, regenerate BibTeX key...
				reference.GenerateBibTeXKey();
				
				Person thirdAuthor = reference.Authors[2];
				
				// check if the third lastname has more than one character...
				if (thirdAuthor.LastName.Length > 1)
				{
					// now fix BibTeXKey
					reference.BibTeXKey = reference.BibTeXKey.Insert(3, thirdAuthor.LastName.Substring(1, 1));
				}
			}
				
		}

	}
}
