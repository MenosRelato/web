module.exports = {
    siteMetadata: {
      title: 'Menos Relato',
      shortName: 'Menos Relato',
      imageUrl: './images/icon.svg',
      header: {
        title: 'Menos Relato',
        url: 'https://menosrelato.org',
        logoUrl: 'https://menosrelato.org',
      },
      description: '(Description)'
    },
    pathPrefix: '/doctocat',
    plugins: [
      {
        resolve: '@primer/gatsby-theme-doctocat',
        options: {
          defaultBranch: 'main',
          icon: './images/icon.svg',
          repoRootPath: '../..'
        },
      },
    ],
  }