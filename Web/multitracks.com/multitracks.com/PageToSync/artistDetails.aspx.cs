using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using DataAccess;

public partial class ArtistDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string artistID = Request.QueryString["artistID"];

            // Default if no artistID
            artistID = string.IsNullOrEmpty(artistID) ? "367" : artistID;

            DataTable artistDetails = GetArtistDetails(artistID);

                if (artistDetails.Rows.Count > 0)
                {
                    dynamic artistData = artistDetails.Rows[0];

                    if (artistData != null)
                    {
                        PopulateArtistControls(artistData);

                        var songList = artistDetails.AsEnumerable()
                            .Where(row => !row.IsNull("songTitle"))
                            .Take(5)
                            .CopyToDataTable();

                    var albumList = artistDetails.AsEnumerable()
                            .Where(row => !row.IsNull("AlbumTitle"))
                            .GroupBy(row => row.Field<string>("AlbumTitle"))
                            .Select(group => group.First())
                            .Take(8)
                            .CopyToDataTable();

                        BindRepeater(songListRepeater, songList);
                        BindRepeater(albumListRepeater, albumList);
                    }
                }
        }
    }
    private DataTable GetArtistDetails(string artistID)
    {
        var sql = new SQL();
        sql.Parameters.Add("@artistID", Convert.ToInt32(artistID));
        return sql.ExecuteStoredProcedureDT("GetArtistDetails");
    }
    private void PopulateArtistControls(DataRow artistData)
    {
        artistName.Text = artistData.Field<string>("artistName");
        artistBio.Text = artistData.Field<string>("artistBio");
        artistImage.ImageUrl = artistData.Field<string>("artistImage");
        artistHero.ImageUrl = artistData.Field<string>("artistHero");
    }
    private void BindRepeater(Repeater repeater, DataTable dataSource)
    {
        repeater.DataSource = dataSource;
        repeater.DataBind();
    }

}