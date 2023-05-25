// Copyright (C) 2023 Antonin Rousseau
// 
// aimxr-toolkit-csharp is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// aimxr-toolkit-csharp is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with aimxr-toolkit-csharp. If not, see <http://www.gnu.org/licenses/>.

using UnityEngine;
using UnityEditor;
namespace AimXRToolkit.Managers;

public class WorkPlaceManager : MonoBehaviour
{
    [SerializeField]
    public LoaderSource loaderSource;
    private Workplace _workplace;
    public async Task<GameObject> SpawnArtifact(int id)
    {
        GameObject artifact = await LoadArtifactModel(id);
        var artifactManager = artifact.AddComponent<ArtifactManager>();
        artifactManager.SetArtifact(await DataManager.GetInstance().GetArtifactAsync(id));
        return artifact;
    }
    public async Task<GameObject> LoadArtifactModel(int id)
    {
        return await loaderSource.LoadGlb(API.ROUTE.ARTIFACTS + id + "/model");
    }

    public void SetWorkplace(Workplace workplace)
    {
        _workplace = workplace;
    }
    public Workplace GetWorkplace()
    {
        return _workplace;
    }
}