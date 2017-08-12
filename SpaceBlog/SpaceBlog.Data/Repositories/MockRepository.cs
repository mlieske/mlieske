using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceBlog.Data.Interfaces;
using SpaceBlog.Models;
using System.Globalization;

namespace SpaceBlog.Data.Repositories
{
    public class MockRepository : ISpaceBlogRepository
    {
        private static List<Post> _posts = new List<Post>();
        private static List<Tag> _tags = new List<Tag>();
        private static List<StaticPage> _staticPages = new List<StaticPage>();

        public MockRepository()
        {
            if (!_posts.Any())
            {
                _posts.AddRange(new List<Post>()
            {
                new Post{
                    PostId = 0,
                    PostBody = "Space... The final Frontier. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent metus nisi, convallis sed tellus sit amet, congue blandit velit. In lorem erat, ornare ac leo at, blandit dapibus nunc. Maecenas ultricies neque sed elit tempus, pellentesque congue tortor rutrum. Ut scelerisque ullamcorper fringilla. Nulla facilisi. Maecenas malesuada lectus vel mi varius euismod. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nulla consequat varius sapien, ut dignissim justo placerat a." +
                        "Mauris congue, massa sit amet commodo mollis, nisl magna dictum ex, et tempus odio ex vel est. Nulla facilisi. Sed sit amet velit vitae enim faucibus gravida ut sit amet odio. Vestibulum eget quam purus. Cras rhoncus tellus id hendrerit hendrerit. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nunc imperdiet lectus at dolor consequat feugiat.Nam ac tempor sapien, nec commodo orci. Mauris id accumsan mauris. Sed a imperdiet sem. Curabitur vehicula eu ante et venenatis. Quisque ac metus elit. Donec quis interdum est. Nulla dignissim blandit dui, vitae semper lacus rhoncus eu." +
                        "Maecenas volutpat imperdiet interdum. Fusce ullamcorper ullamcorper lectus. Duis ligula velit, sagittis elementum ultrices eget, ultricies eget nunc. Maecenas ac diam consequat, efficitur erat eu, feugiat est.In semper iaculis elit interdum aliquam. In in mauris ac urna mattis molestie.Aenean dictum vitae dolor quis tincidunt. Suspendisse bibendum a felis in interdum.Fusce sodales finibus varius. In turpis massa, tincidunt id lorem fringilla, hendrerit suscipit neque. Sed id nibh fermentum, bibendum nisi vel, commodo urna.Curabitur porttitor aliquet orci eget aliquet. In ac ligula porta, auctor ante ut, elementum nisi.Etiam eu aliquam lorem, et dignissim urna. Etiam molestie ante magna, vitae sodales est pellentesque ac."+
                        "Etiam lacinia, orci sit amet lobortis dictum, urna augue dictum mauris, vel pharetra lacus justo ut sem. Duis semper, orci at lacinia luctus, odio metus ultrices augue, eget accumsan lectus leo nec leo.Interdum et malesuada fames ac ante ipsum primis in faucibus.Curabitur malesuada aliquam justo, et pretium nisl fringilla quis. Sed ac feugiat ante. Nullam ultricies leo at nisi efficitur, eu dapibus orci blandit.Morbi luctus ipsum ut porttitor tristique. Nulla viverra auctor risus vitae maximus. Cras tortor enim, porttitor vitae sollicitudin ut, pharetra et est. Sed commodo auctor urna, quis tristique libero ultricies non. Praesent sagittis ligula varius est feugiat fringilla."+
                        "Aenean convallis varius magna quis sodales. Aliquam id nulla nisl. Fusce ut ultrices enim. Etiam varius nunc id porttitor imperdiet. Ut neque turpis, molestie at dui et, semper blandit tortor. Ut sit amet tortor id lorem maximus ornare non ac enim.Suspendisse vel augue libero.",
                    PostTitle = "OMG",
                    ApprovalStatus = true,
                    CreationDate = DateTime.ParseExact("11/1/2016", "MM/d/yyyy", CultureInfo.InvariantCulture),
                    ExpirationDate = DateTime.ParseExact("12/1/2016", "MM/d/yyyy", CultureInfo.InvariantCulture),
                    ImageFileName = "/Website IMAGES/placeholder5.jpg",
                    UserId = "1337",
                    Tags = new List<Tag>()

               },
                new Post{
                    PostId = 1,
                    PostBody = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent metus nisi, convallis sed tellus sit amet, congue blandit velit. In lorem erat, ornare ac leo at, blandit dapibus nunc. Maecenas ultricies neque sed elit tempus, pellentesque congue tortor rutrum. Ut scelerisque ullamcorper fringilla. Nulla facilisi. Maecenas malesuada lectus vel mi varius euismod. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nulla consequat varius sapien, ut dignissim justo placerat a." +
                        "Mauris congue, massa sit amet commodo mollis, nisl magna dictum ex, et tempus odio ex vel est. Nulla facilisi. Sed sit amet velit vitae enim faucibus gravida ut sit amet odio. Vestibulum eget quam purus. Cras rhoncus tellus id hendrerit hendrerit. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nunc imperdiet lectus at dolor consequat feugiat.Nam ac tempor sapien, nec commodo orci. Mauris id accumsan mauris. Sed a imperdiet sem. Curabitur vehicula eu ante et venenatis. Quisque ac metus elit. Donec quis interdum est. Nulla dignissim blandit dui, vitae semper lacus rhoncus eu." +
                        "Maecenas volutpat imperdiet interdum. Fusce ullamcorper ullamcorper lectus. Duis ligula velit, sagittis elementum ultrices eget, ultricies eget nunc. Maecenas ac diam consequat, efficitur erat eu, feugiat est.In semper iaculis elit interdum aliquam. In in mauris ac urna mattis molestie.Aenean dictum vitae dolor quis tincidunt. Suspendisse bibendum a felis in interdum.Fusce sodales finibus varius. In turpis massa, tincidunt id lorem fringilla, hendrerit suscipit neque. Sed id nibh fermentum, bibendum nisi vel, commodo urna.Curabitur porttitor aliquet orci eget aliquet. In ac ligula porta, auctor ante ut, elementum nisi.Etiam eu aliquam lorem, et dignissim urna. Etiam molestie ante magna, vitae sodales est pellentesque ac."+
                        "Etiam lacinia, orci sit amet lobortis dictum, urna augue dictum mauris, vel pharetra lacus justo ut sem. Duis semper, orci at lacinia luctus, odio metus ultrices augue, eget accumsan lectus leo nec leo.Interdum et malesuada fames ac ante ipsum primis in faucibus.Curabitur malesuada aliquam justo, et pretium nisl fringilla quis. Sed ac feugiat ante. Nullam ultricies leo at nisi efficitur, eu dapibus orci blandit.Morbi luctus ipsum ut porttitor tristique. Nulla viverra auctor risus vitae maximus. Cras tortor enim, porttitor vitae sollicitudin ut, pharetra et est. Sed commodo auctor urna, quis tristique libero ultricies non. Praesent sagittis ligula varius est feugiat fringilla."+
                        "Aenean convallis varius magna quis sodales. Aliquam id nulla nisl. Fusce ut ultrices enim. Etiam varius nunc id porttitor imperdiet. Ut neque turpis, molestie at dui et, semper blandit tortor. Ut sit amet tortor id lorem maximus ornare non ac enim.Suspendisse vel augue libero.",
                    PostTitle = "Example Post Title",
                    ApprovalStatus = true,
                    CreationDate = DateTime.ParseExact("10/1/2016", "MM/d/yyyy", CultureInfo.InvariantCulture),
                    ExpirationDate = DateTime.ParseExact("12/1/2016", "MM/d/yyyy", CultureInfo.InvariantCulture),
                    ImageFileName = "/Website IMAGES/placeholder2.jpg",
                    UserId = "1",
                    Tags = new List<Tag>()

                },
                new Post{
                    PostId = 2,
                    PostBody = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent metus nisi, convallis sed tellus sit amet, congue blandit velit. In lorem erat, ornare ac leo at, blandit dapibus nunc. Maecenas ultricies neque sed elit tempus, pellentesque congue tortor rutrum. Ut scelerisque ullamcorper fringilla. Nulla facilisi. Maecenas malesuada lectus vel mi varius euismod. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nulla consequat varius sapien, ut dignissim justo placerat a." +
                        "Mauris congue, massa sit amet commodo mollis, nisl magna dictum ex, et tempus odio ex vel est. Nulla facilisi. Sed sit amet velit vitae enim faucibus gravida ut sit amet odio. Vestibulum eget quam purus. Cras rhoncus tellus id hendrerit hendrerit. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nunc imperdiet lectus at dolor consequat feugiat.Nam ac tempor sapien, nec commodo orci. Mauris id accumsan mauris. Sed a imperdiet sem. Curabitur vehicula eu ante et venenatis. Quisque ac metus elit. Donec quis interdum est. Nulla dignissim blandit dui, vitae semper lacus rhoncus eu." +
                        "Maecenas volutpat imperdiet interdum. Fusce ullamcorper ullamcorper lectus. Duis ligula velit, sagittis elementum ultrices eget, ultricies eget nunc. Maecenas ac diam consequat, efficitur erat eu, feugiat est.In semper iaculis elit interdum aliquam. In in mauris ac urna mattis molestie.Aenean dictum vitae dolor quis tincidunt. Suspendisse bibendum a felis in interdum.Fusce sodales finibus varius. In turpis massa, tincidunt id lorem fringilla, hendrerit suscipit neque. Sed id nibh fermentum, bibendum nisi vel, commodo urna.Curabitur porttitor aliquet orci eget aliquet. In ac ligula porta, auctor ante ut, elementum nisi.Etiam eu aliquam lorem, et dignissim urna. Etiam molestie ante magna, vitae sodales est pellentesque ac."+
                        "Etiam lacinia, orci sit amet lobortis dictum, urna augue dictum mauris, vel pharetra lacus justo ut sem. Duis semper, orci at lacinia luctus, odio metus ultrices augue, eget accumsan lectus leo nec leo.Interdum et malesuada fames ac ante ipsum primis in faucibus.Curabitur malesuada aliquam justo, et pretium nisl fringilla quis. Sed ac feugiat ante. Nullam ultricies leo at nisi efficitur, eu dapibus orci blandit.Morbi luctus ipsum ut porttitor tristique. Nulla viverra auctor risus vitae maximus. Cras tortor enim, porttitor vitae sollicitudin ut, pharetra et est. Sed commodo auctor urna, quis tristique libero ultricies non. Praesent sagittis ligula varius est feugiat fringilla."+
                        "Aenean convallis varius magna quis sodales. Aliquam id nulla nisl. Fusce ut ultrices enim. Etiam varius nunc id porttitor imperdiet. Ut neque turpis, molestie at dui et, semper blandit tortor. Ut sit amet tortor id lorem maximus ornare non ac enim.Suspendisse vel augue libero.",
                    PostTitle = "Example Post Title 2",
                    CreationDate = DateTime.ParseExact("12/1/2016", "MM/d/yyyy", CultureInfo.InvariantCulture),
                    ExpirationDate = DateTime.ParseExact("12/1/2016", "MM/d/yyyy", CultureInfo.InvariantCulture),
                    ImageFileName = "/Website IMAGES/placeholder3.jpg",
                    UserId = "1",
                    Tags = new List<Tag>()
                },
                new Post{
                    PostId = 3,
                    PostBody = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent metus nisi, convallis sed tellus sit amet, congue blandit velit. In lorem erat, ornare ac leo at, blandit dapibus nunc. Maecenas ultricies neque sed elit tempus, pellentesque congue tortor rutrum. Ut scelerisque ullamcorper fringilla. Nulla facilisi. Maecenas malesuada lectus vel mi varius euismod. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nulla consequat varius sapien, ut dignissim justo placerat a." +
                        "Mauris congue, massa sit amet commodo mollis, nisl magna dictum ex, et tempus odio ex vel est. Nulla facilisi. Sed sit amet velit vitae enim faucibus gravida ut sit amet odio. Vestibulum eget quam purus. Cras rhoncus tellus id hendrerit hendrerit. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nunc imperdiet lectus at dolor consequat feugiat.Nam ac tempor sapien, nec commodo orci. Mauris id accumsan mauris. Sed a imperdiet sem. Curabitur vehicula eu ante et venenatis. Quisque ac metus elit. Donec quis interdum est. Nulla dignissim blandit dui, vitae semper lacus rhoncus eu." +
                        "Maecenas volutpat imperdiet interdum. Fusce ullamcorper ullamcorper lectus. Duis ligula velit, sagittis elementum ultrices eget, ultricies eget nunc. Maecenas ac diam consequat, efficitur erat eu, feugiat est.In semper iaculis elit interdum aliquam. In in mauris ac urna mattis molestie.Aenean dictum vitae dolor quis tincidunt. Suspendisse bibendum a felis in interdum.Fusce sodales finibus varius. In turpis massa, tincidunt id lorem fringilla, hendrerit suscipit neque. Sed id nibh fermentum, bibendum nisi vel, commodo urna.Curabitur porttitor aliquet orci eget aliquet. In ac ligula porta, auctor ante ut, elementum nisi.Etiam eu aliquam lorem, et dignissim urna. Etiam molestie ante magna, vitae sodales est pellentesque ac."+
                        "Etiam lacinia, orci sit amet lobortis dictum, urna augue dictum mauris, vel pharetra lacus justo ut sem. Duis semper, orci at lacinia luctus, odio metus ultrices augue, eget accumsan lectus leo nec leo.Interdum et malesuada fames ac ante ipsum primis in faucibus.Curabitur malesuada aliquam justo, et pretium nisl fringilla quis. Sed ac feugiat ante. Nullam ultricies leo at nisi efficitur, eu dapibus orci blandit.Morbi luctus ipsum ut porttitor tristique. Nulla viverra auctor risus vitae maximus. Cras tortor enim, porttitor vitae sollicitudin ut, pharetra et est. Sed commodo auctor urna, quis tristique libero ultricies non. Praesent sagittis ligula varius est feugiat fringilla."+
                        "Aenean convallis varius magna quis sodales. Aliquam id nulla nisl. Fusce ut ultrices enim. Etiam varius nunc id porttitor imperdiet. Ut neque turpis, molestie at dui et, semper blandit tortor. Ut sit amet tortor id lorem maximus ornare non ac enim.Suspendisse vel augue libero.",
                    PostTitle = "Example Post Title 3",
                    CreationDate = DateTime.ParseExact("12/1/2016", "MM/d/yyyy", CultureInfo.InvariantCulture),
                    ExpirationDate = DateTime.ParseExact("12/1/2016", "MM/d/yyyy", CultureInfo.InvariantCulture),
                    ImageFileName = "/Website IMAGES/placeholder4.jpg",
                    UserId = "1",
                    Tags = new List<Tag>()
                },
                new Post{
                    PostId = 4,
                    PostBody = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent metus nisi, convallis sed tellus sit amet, congue blandit velit. In lorem erat, ornare ac leo at, blandit dapibus nunc. Maecenas ultricies neque sed elit tempus, pellentesque congue tortor rutrum. Ut scelerisque ullamcorper fringilla. Nulla facilisi. Maecenas malesuada lectus vel mi varius euismod. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nulla consequat varius sapien, ut dignissim justo placerat a." +
                        "Mauris congue, massa sit amet commodo mollis, nisl magna dictum ex, et tempus odio ex vel est. Nulla facilisi. Sed sit amet velit vitae enim faucibus gravida ut sit amet odio. Vestibulum eget quam purus. Cras rhoncus tellus id hendrerit hendrerit. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nunc imperdiet lectus at dolor consequat feugiat.Nam ac tempor sapien, nec commodo orci. Mauris id accumsan mauris. Sed a imperdiet sem. Curabitur vehicula eu ante et venenatis. Quisque ac metus elit. Donec quis interdum est. Nulla dignissim blandit dui, vitae semper lacus rhoncus eu." +
                        "Maecenas volutpat imperdiet interdum. Fusce ullamcorper ullamcorper lectus. Duis ligula velit, sagittis elementum ultrices eget, ultricies eget nunc. Maecenas ac diam consequat, efficitur erat eu, feugiat est.In semper iaculis elit interdum aliquam. In in mauris ac urna mattis molestie.Aenean dictum vitae dolor quis tincidunt. Suspendisse bibendum a felis in interdum.Fusce sodales finibus varius. In turpis massa, tincidunt id lorem fringilla, hendrerit suscipit neque. Sed id nibh fermentum, bibendum nisi vel, commodo urna.Curabitur porttitor aliquet orci eget aliquet. In ac ligula porta, auctor ante ut, elementum nisi.Etiam eu aliquam lorem, et dignissim urna. Etiam molestie ante magna, vitae sodales est pellentesque ac."+
                        "Etiam lacinia, orci sit amet lobortis dictum, urna augue dictum mauris, vel pharetra lacus justo ut sem. Duis semper, orci at lacinia luctus, odio metus ultrices augue, eget accumsan lectus leo nec leo.Interdum et malesuada fames ac ante ipsum primis in faucibus.Curabitur malesuada aliquam justo, et pretium nisl fringilla quis. Sed ac feugiat ante. Nullam ultricies leo at nisi efficitur, eu dapibus orci blandit.Morbi luctus ipsum ut porttitor tristique. Nulla viverra auctor risus vitae maximus. Cras tortor enim, porttitor vitae sollicitudin ut, pharetra et est. Sed commodo auctor urna, quis tristique libero ultricies non. Praesent sagittis ligula varius est feugiat fringilla."+
                        "Aenean convallis varius magna quis sodales. Aliquam id nulla nisl. Fusce ut ultrices enim. Etiam varius nunc id porttitor imperdiet. Ut neque turpis, molestie at dui et, semper blandit tortor. Ut sit amet tortor id lorem maximus ornare non ac enim.Suspendisse vel augue libero.",
                    PostTitle = "Example Post Title 4",
                    CreationDate = DateTime.ParseExact("12/1/2016", "MM/d/yyyy", CultureInfo.InvariantCulture),
                    ExpirationDate = DateTime.ParseExact("12/1/2016", "MM/d/yyyy", CultureInfo.InvariantCulture),
                    ImageFileName = "/Website IMAGES/placeholder5.jpg",
                    UserId = "1",
                    Tags = new List<Tag>()
                },
                new Post{
                    PostId = 5,
                    PostBody = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent metus nisi, convallis sed tellus sit amet, congue blandit velit. In lorem erat, ornare ac leo at, blandit dapibus nunc. Maecenas ultricies neque sed elit tempus, pellentesque congue tortor rutrum. Ut scelerisque ullamcorper fringilla. Nulla facilisi. Maecenas malesuada lectus vel mi varius euismod. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nulla consequat varius sapien, ut dignissim justo placerat a." +
                        "Mauris congue, massa sit amet commodo mollis, nisl magna dictum ex, et tempus odio ex vel est. Nulla facilisi. Sed sit amet velit vitae enim faucibus gravida ut sit amet odio. Vestibulum eget quam purus. Cras rhoncus tellus id hendrerit hendrerit. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nunc imperdiet lectus at dolor consequat feugiat.Nam ac tempor sapien, nec commodo orci. Mauris id accumsan mauris. Sed a imperdiet sem. Curabitur vehicula eu ante et venenatis. Quisque ac metus elit. Donec quis interdum est. Nulla dignissim blandit dui, vitae semper lacus rhoncus eu." +
                        "Maecenas volutpat imperdiet interdum. Fusce ullamcorper ullamcorper lectus. Duis ligula velit, sagittis elementum ultrices eget, ultricies eget nunc. Maecenas ac diam consequat, efficitur erat eu, feugiat est.In semper iaculis elit interdum aliquam. In in mauris ac urna mattis molestie.Aenean dictum vitae dolor quis tincidunt. Suspendisse bibendum a felis in interdum.Fusce sodales finibus varius. In turpis massa, tincidunt id lorem fringilla, hendrerit suscipit neque. Sed id nibh fermentum, bibendum nisi vel, commodo urna.Curabitur porttitor aliquet orci eget aliquet. In ac ligula porta, auctor ante ut, elementum nisi.Etiam eu aliquam lorem, et dignissim urna. Etiam molestie ante magna, vitae sodales est pellentesque ac."+
                        "Etiam lacinia, orci sit amet lobortis dictum, urna augue dictum mauris, vel pharetra lacus justo ut sem. Duis semper, orci at lacinia luctus, odio metus ultrices augue, eget accumsan lectus leo nec leo.Interdum et malesuada fames ac ante ipsum primis in faucibus.Curabitur malesuada aliquam justo, et pretium nisl fringilla quis. Sed ac feugiat ante. Nullam ultricies leo at nisi efficitur, eu dapibus orci blandit.Morbi luctus ipsum ut porttitor tristique. Nulla viverra auctor risus vitae maximus. Cras tortor enim, porttitor vitae sollicitudin ut, pharetra et est. Sed commodo auctor urna, quis tristique libero ultricies non. Praesent sagittis ligula varius est feugiat fringilla."+
                        "Aenean convallis varius magna quis sodales. Aliquam id nulla nisl. Fusce ut ultrices enim. Etiam varius nunc id porttitor imperdiet. Ut neque turpis, molestie at dui et, semper blandit tortor. Ut sit amet tortor id lorem maximus ornare non ac enim.Suspendisse vel augue libero.",
                    PostTitle = "Example Post Title 5",
                    CreationDate = DateTime.ParseExact("12/1/2016", "MM/d/yyyy", CultureInfo.InvariantCulture),
                    ExpirationDate = DateTime.ParseExact("12/1/2016", "MM/d/yyyy", CultureInfo.InvariantCulture),
                    ImageFileName = "/Website IMAGES/placeholder2.jpg",
                    UserId = "ef622078-21a7-49f2-8973-ac14943be599",
                    Tags = new List<Tag>()
                },
                new Post{
                    PostId = 6,
                    PostBody = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent metus nisi, convallis sed tellus sit amet, congue blandit velit. In lorem erat, ornare ac leo at, blandit dapibus nunc. Maecenas ultricies neque sed elit tempus, pellentesque congue tortor rutrum. Ut scelerisque ullamcorper fringilla. Nulla facilisi. Maecenas malesuada lectus vel mi varius euismod. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nulla consequat varius sapien, ut dignissim justo placerat a." +
                        "Mauris congue, massa sit amet commodo mollis, nisl magna dictum ex, et tempus odio ex vel est. Nulla facilisi. Sed sit amet velit vitae enim faucibus gravida ut sit amet odio. Vestibulum eget quam purus. Cras rhoncus tellus id hendrerit hendrerit. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nunc imperdiet lectus at dolor consequat feugiat.Nam ac tempor sapien, nec commodo orci. Mauris id accumsan mauris. Sed a imperdiet sem. Curabitur vehicula eu ante et venenatis. Quisque ac metus elit. Donec quis interdum est. Nulla dignissim blandit dui, vitae semper lacus rhoncus eu." +
                        "Maecenas volutpat imperdiet interdum. Fusce ullamcorper ullamcorper lectus. Duis ligula velit, sagittis elementum ultrices eget, ultricies eget nunc. Maecenas ac diam consequat, efficitur erat eu, feugiat est.In semper iaculis elit interdum aliquam. In in mauris ac urna mattis molestie.Aenean dictum vitae dolor quis tincidunt. Suspendisse bibendum a felis in interdum.Fusce sodales finibus varius. In turpis massa, tincidunt id lorem fringilla, hendrerit suscipit neque. Sed id nibh fermentum, bibendum nisi vel, commodo urna.Curabitur porttitor aliquet orci eget aliquet. In ac ligula porta, auctor ante ut, elementum nisi.Etiam eu aliquam lorem, et dignissim urna. Etiam molestie ante magna, vitae sodales est pellentesque ac."+
                        "Etiam lacinia, orci sit amet lobortis dictum, urna augue dictum mauris, vel pharetra lacus justo ut sem. Duis semper, orci at lacinia luctus, odio metus ultrices augue, eget accumsan lectus leo nec leo.Interdum et malesuada fames ac ante ipsum primis in faucibus.Curabitur malesuada aliquam justo, et pretium nisl fringilla quis. Sed ac feugiat ante. Nullam ultricies leo at nisi efficitur, eu dapibus orci blandit.Morbi luctus ipsum ut porttitor tristique. Nulla viverra auctor risus vitae maximus. Cras tortor enim, porttitor vitae sollicitudin ut, pharetra et est. Sed commodo auctor urna, quis tristique libero ultricies non. Praesent sagittis ligula varius est feugiat fringilla."+
                        "Aenean convallis varius magna quis sodales. Aliquam id nulla nisl. Fusce ut ultrices enim. Etiam varius nunc id porttitor imperdiet. Ut neque turpis, molestie at dui et, semper blandit tortor. Ut sit amet tortor id lorem maximus ornare non ac enim.Suspendisse vel augue libero.",
                    PostTitle = "Example Post Title 6",
                    CreationDate = DateTime.ParseExact("12/1/2016", "MM/d/yyyy", CultureInfo.InvariantCulture),
                    ExpirationDate = DateTime.ParseExact("12/1/2016", "MM/d/yyyy", CultureInfo.InvariantCulture),
                    ImageFileName = "/Website IMAGES/placeholder3.jpg",
                    UserId = "ef622078-21a7-49f2-8973-ac14943be599",
                    Tags = new List<Tag>()
                }
            });
            }

            if (!_tags.Any())
            {
                _tags.AddRange(new List<Tag>()
                //{

                    //_tags = new List<Tag>
            {
                new Tag{
                    TagId = 1,
                    TagName = "#Excellent",
                    Posts = new List<Post>()
                },
                new Tag
                {
                    TagId = 2,
                    TagName = "#Post",
                    Posts = new List<Post>()
                },
                new Tag
                {
                    TagId = 3,
                    TagName = "#Tag",
                    Posts = new List<Post>()
                },
                new Tag
                {
                    TagId = 4,
                    TagName = "#Wow",
                    Posts = new List<Post>()
                },
                new Tag
                {
                    TagId = 5,
                    TagName = "#Space",
                    Posts = new List<Post>()
                }
            });

                _posts.Single(p => p.PostId == 1).Tags.Add(_tags.Single(t => t.TagId == 1));
                _posts.Single(p => p.PostId == 1).Tags.Add(_tags.Single(t => t.TagId == 2));
                _posts.Single(p => p.PostId == 1).Tags.Add(_tags.Single(t => t.TagId == 3));
                _posts.Single(p => p.PostId == 2).Tags.Add(_tags.Single(t => t.TagId == 1));
                _posts.Single(p => p.PostId == 2).Tags.Add(_tags.Single(t => t.TagId == 5));
                _posts.Single(p => p.PostId == 2).Tags.Add(_tags.Single(t => t.TagId == 3));
                _posts.Single(p => p.PostId == 3).Tags.Add(_tags.Single(t => t.TagId == 4));
                _posts.Single(p => p.PostId == 4).Tags.Add(_tags.Single(t => t.TagId == 3));
                _posts.Single(p => p.PostId == 5).Tags.Add(_tags.Single(t => t.TagId == 2));
                _posts.Single(p => p.PostId == 6).Tags.Add(_tags.Single(t => t.TagId == 1));

                _tags.Single(t => t.TagId == 1).Posts.Add(_posts.Single(p => p.PostId == 1));
                _tags.Single(t => t.TagId == 2).Posts.Add(_posts.Single(p => p.PostId == 1));
                _tags.Single(t => t.TagId == 3).Posts.Add(_posts.Single(p => p.PostId == 1));
                _tags.Single(t => t.TagId == 1).Posts.Add(_posts.Single(p => p.PostId == 2));
                _tags.Single(t => t.TagId == 5).Posts.Add(_posts.Single(p => p.PostId == 2));
                _tags.Single(t => t.TagId == 3).Posts.Add(_posts.Single(p => p.PostId == 2));
                _tags.Single(t => t.TagId == 4).Posts.Add(_posts.Single(p => p.PostId == 3));
                _tags.Single(t => t.TagId == 3).Posts.Add(_posts.Single(p => p.PostId == 4));
                _tags.Single(t => t.TagId == 2).Posts.Add(_posts.Single(p => p.PostId == 5));
                _tags.Single(t => t.TagId == 1).Posts.Add(_posts.Single(p => p.PostId == 6));

            }

            if (!_staticPages.Any())
            {
                _staticPages.AddRange(new List<StaticPage>()
                {
                    new StaticPage
                    {
                        StaticPageId = 1,
                        StaticPageTitle = "Static Page Title 1",
                        StaticPageBody = "Static Page Body 1",
                        ImageFileName = "~/Images/placeholder.jpg"
                    },
                    new StaticPage
                    {
                        StaticPageId = 2,
                        StaticPageTitle = "Static Page Title 2",
                        StaticPageBody = "Static Page Body 2",
                        ImageFileName = "~/Images/placeholder.jpg"
                    },
                    new StaticPage
                    {
                        StaticPageId = 3,
                        StaticPageTitle = "Static Page Title 3",
                        StaticPageBody = "Static Page Body 3",
                        ImageFileName = "~/Images/placeholder.jpg"
                    },
                    new StaticPage
                    {
                        StaticPageId = 4,
                        StaticPageTitle = "Static Page Title 4",
                        StaticPageBody = "Static Page Body 4",
                        ImageFileName = "~/Images/placeholder.jpg"
                    }
                });
            }
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _posts;
        }

        public IEnumerable<Tag> GetAllTags()
        {
            return _tags;
        }

        public IEnumerable<StaticPage> GetAllStaticPages()
        {
            return _staticPages;
        }

        public void EditPost(Post post)
        {
            Post toUpdate = _posts.FirstOrDefault(p => p.PostId == post.PostId);
            toUpdate.ApprovalStatus = post.ApprovalStatus;
            toUpdate.CreationDate = post.CreationDate;
            toUpdate.ExpirationDate = post.ExpirationDate;
            toUpdate.ImageFileName = post.ImageFileName;
            toUpdate.PostBody = post.PostBody;
            toUpdate.PostId = post.PostId;
            toUpdate.PostTitle = post.PostTitle;
            toUpdate.UserId = post.UserId;
            toUpdate.Tags = post.Tags;
            //foreach (var tag in post.Tags)
            //{
            //    toUpdate.Tags.Add(tag);
            //}
            DeletePost(post.PostId);
            InsertPost(toUpdate);
        }

        public void SetPostToApproved(int id)
        {
            var found = _posts.FirstOrDefault(p => p.PostId == id);
            found.ApprovalStatus = true;
        }

        public void EditTag(Tag tag)
        {
            Tag toUpdate = _tags.FirstOrDefault(t => t.TagId == tag.TagId);
            toUpdate.TagId = tag.TagId;
            toUpdate.TagName = tag.TagName;
        }

        public void EditStaticPage(StaticPage staticpage)
        {
            StaticPage toUpdate = _staticPages.FirstOrDefault(s => s.StaticPageId == staticpage.StaticPageId);
            toUpdate.StaticPageId = staticpage.StaticPageId;
            toUpdate.StaticPageTitle = staticpage.StaticPageTitle;
            toUpdate.StaticPageBody = staticpage.StaticPageBody;
            toUpdate.ImageFileName = staticpage.ImageFileName;
        }

        public void DeletePost(int PostId)
        {
            _posts.Remove(_posts.FirstOrDefault(p => p.PostId == PostId));
        }

        public void DeleteRole(int roleId)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public void DeleteTag(int tagId)
        {
            _tags.Remove(_tags.FirstOrDefault(t => t.TagId == tagId));
        }

        public void DeleteStaticPage(int staticpageId)
        {
            _staticPages.Remove(_staticPages.FirstOrDefault(s => s.StaticPageId == staticpageId));
        }

        public void InsertPost(Post post)
        {
            var newId = _posts.Max(p => p.PostId) + 1;
            post.PostId = newId;
            _posts.Add(post);
        }

        public void InsertTag(Tag tag)
        {
            _tags.Add(tag);
        }

        public void InsertStaticPage(StaticPage staticpage)
        {
            _staticPages.Add(staticpage);
        }

        public Post GetTop10PostsByTags(Tag tag)
        {
            //            var topTen = _posts.Where(p => p.Tags.Count(t => t.TagName == tag.TagName)).OrderByDescending(t => t.Tags).Take(10);
            //            return topTen;
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetPostByTag(string tagName)
        {
            return _posts.Where(p => p.Tags.Any(t => t.TagName == tagName));
        }

        public Post GetPostById(int postId)
        {
            return _posts.FirstOrDefault(p => p.PostId == postId);
        }

        public Tag GetTagByName(string tagName)
        {
            return _tags.FirstOrDefault(t => t.TagName == tagName);
        }

        public Tag GetTagById(int tagId)
        {
            return _tags.FirstOrDefault(t => t.TagId == tagId);
        }

        public StaticPage GetStaticPageById(int pageId)
        {

            return _staticPages.FirstOrDefault(s => s.StaticPageId == pageId);
        }


        public IEnumerable<Tag> GetTopTenTags()
        {
            var tags = _tags.OrderByDescending(t => t.Posts.Count()).Take(10);
            return tags;
        }

        public IEnumerable<Post> GetApprovedPosts()
        {
            return _posts.Where(p => p.ApprovalStatus == true);
        }

        public IEnumerable<Post> GetPostByTitle(string postTitle)
        {
            var postsByTitle = new List<Post>();

            foreach (var post in _posts)
            {
                if (post.PostTitle.Contains(postTitle))
                    postsByTitle.Add(post);
            }
            return postsByTitle;
        }

        public IEnumerable<Post> GetPostsByUser(string userName)
        {
            return _posts.Where(p => p.UserId == userName);
        }
    }
}
